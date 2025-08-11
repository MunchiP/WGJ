using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightActivator : MonoBehaviour
{
 [Header("References")]
    public LightDetection lightDetection; 
    public Light2D pointLight;            

    [Header("Timing (segundos)")]
    public bool toggleAutomatically = true;
    public float minOnTime = 3f;
    public float maxOnTime = 6f;
    public float minOffTime = 4f;
    public float maxOffTime = 10f;

    [Header("Warning")]
    public string warningSound = ""; // nombre en AudioManager
    public float warningDelay = 1.2f; // tiempo entre advertencia y encendido

    [Header("Startup")]
    public bool startOff = true; // si true, asegura que empiece apagada

    [Header("Visual")]
    public float alphaOn = 1f;
    public float alphaOff = 0.3f;

    [Header("Debug")]
    public bool debugLogs = false;

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        // Forzar estado inicial (muy importante para evitar overrides)
        bool startOn = !startOff;
        if (lightDetection != null) lightDetection.isActive = startOn;
        if (pointLight != null) pointLight.enabled = startOn;
        UpdateSpriteAlpha(startOn);
    }

    void Start()
    {
        if (toggleAutomatically)
            StartCoroutine(AutoRoutine());
    }

    IEnumerator AutoRoutine()
    {
        // pequeña espera aleatoria antes de arrancar para variar las lámparas en la escena
        yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));

        while (true)
        {
            // Si está apagada → esperar offTime, advertir, luego encender y esperar onTime
            if (lightDetection == null || pointLight == null)
            {
                if (debugLogs) Debug.LogWarning("Faltan referencias en LightActivator_URP", this);
                yield break;
            }

            if (!lightDetection.isActive)
            {
                float offTime = Random.Range(minOffTime, maxOffTime);
                yield return new WaitForSeconds(offTime);

                // advertencia sonora antes de encender
                if (!string.IsNullOrEmpty(warningSound) && AudioManager.Instance != null)
                {
                    AudioManager.Instance.Play(warningSound);
                }

                yield return new WaitForSeconds(warningDelay);

                SetLight(true);

                float onTime = Random.Range(minOnTime, maxOnTime);
                yield return new WaitForSeconds(onTime);

                SetLight(false);
            }
            else
            {
                // si por alguna razón está encendida, apagar luego de un ciclo
                float onTime = Random.Range(minOnTime, maxOnTime);
                yield return new WaitForSeconds(onTime);
                SetLight(false);
            }
        }
    }

    public void ToggleLight()
    {
        SetLight(!lightDetection.isActive);
    }

    public void SetLight(bool on)
    {
        if (lightDetection != null) lightDetection.isActive = on;
        if (pointLight != null) pointLight.enabled = on;
        UpdateSpriteAlpha(on);

        if (debugLogs) Debug.Log($"{name} SetLight -> {on}", this);
    }

    void UpdateSpriteAlpha(bool on)
    {
        if (sr == null) return;
        Color c = sr.color;
        c.a = on ? alphaOn : alphaOff;
        sr.color = c;
    }
}
