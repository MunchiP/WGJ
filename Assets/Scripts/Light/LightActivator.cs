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
    public string warningSound = "";
    public float warningDelay = 1.2f;

    [Header("Startup")]
    public bool startOff = true;

    [Header("Light Intensities")]
    public float lightDimIntensity = 0.2f;  // luz tenue constante
    public float lightOnIntensity = 3f;     // luz fuerte cuando está encendida

    [Header("Visual")]
    public float alphaOn = 1f;
    public float alphaOff = 0.3f;

    [Header("Debug")]
    public bool debugLogs = true;

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        bool startOn = !startOff;
        if (lightDetection != null) lightDetection.isActive = startOn;

        if (pointLight != null)
            pointLight.intensity = startOn ? lightOnIntensity : lightDimIntensity;

        UpdateSpriteAlpha(startOn);

        if (debugLogs) Debug.Log($"{name} Awake -> startOn={startOn}, intensity={pointLight.intensity}", this);
    }

    void Start()
    {
        if (toggleAutomatically)
            StartCoroutine(AutoRoutine());
            
    }

    IEnumerator AutoRoutine()
    {
        Debug.Log("Iniciando AutoRoutine", this);
        yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));

        while (true)
        {
            if (lightDetection == null || pointLight == null)
            {
                Debug.LogWarning("Faltan referencias en LightActivator", this);
                yield break;
            }

            if (!lightDetection.isActive)
            {
                yield return new WaitForSeconds(Random.Range(minOffTime, maxOffTime));

                if (!string.IsNullOrEmpty(warningSound) && AudioManager.Instance != null)
                    AudioManager.Instance.Play(warningSound);

                yield return new WaitForSeconds(warningDelay);

                SetLight(true);
                yield return new WaitForSeconds(Random.Range(minOnTime, maxOnTime));
                SetLight(false);
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(minOnTime, maxOnTime));
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

        if (pointLight != null)
            pointLight.intensity = on ? lightOnIntensity : lightDimIntensity;

        UpdateSpriteAlpha(on);

        if (debugLogs) Debug.Log($"{name} SetLight -> {on}, intensity={pointLight.intensity}", this);
    }

    void UpdateSpriteAlpha(bool on)
    {
        if (sr != null)
        {
            Color c = sr.color;
            c.a = on ? alphaOn : alphaOff;
            sr.color = c;
        }
    }
}