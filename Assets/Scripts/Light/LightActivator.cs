using System.Collections;
using UnityEngine;

public class LightActivator : MonoBehaviour
{
 public LightDetection lightDetection; // referencia al script LightDetection
    public bool toggleAutomatically = true;
    public float toggleInterval = 3f;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (toggleAutomatically)
        {
            StartCoroutine(ToggleLightRoutine());
        }
    }

    private IEnumerator ToggleLightRoutine()
    {
        while (true)
        {
            ToggleLight();
            yield return new WaitForSeconds(toggleInterval);
        }
    }

    public void ToggleLight()
    {
        if (lightDetection == null) return;

        lightDetection.isActive = !lightDetection.isActive;

        if (sr != null)
        {
            Color c = sr.color;
            c.a = lightDetection.isActive ? 1f : 0.3f; // transparencia cuando está apagada
            sr.color = c;
        }
    }
}
