using UnityEngine;

public class EnableEmission : MonoBehaviour
{
    private Light[] lights; 

    [SerializeField]
    private Renderer[] yellowObjects;
    [SerializeField]
    private Color yellowEmission = Color.yellow;

    [SerializeField]
    private Renderer[] orangeObjects;
    [SerializeField]
    private Color orangeEmission = new(1f, 0.5f, 0f);

    [SerializeField]
    private Renderer[] redObjects;
    [SerializeField]
    private Color redEmission = Color.red;

    private bool isEmissionOn = false;

    private void Start()
    {
        lights = GetComponentsInChildren<Light>();
        SetLights();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isEmissionOn = !isEmissionOn;
            UpdateAllEmission();
            SetLights();
        }
    }

    private void SetLights()
    {
        foreach (Light light in lights)
        {
            light.enabled = isEmissionOn ? true : false;
        }
    }

    private void UpdateAllEmission()
    {
        SetEmissionForGroup(yellowObjects, isEmissionOn ? yellowEmission : Color.black);
        SetEmissionForGroup(orangeObjects, isEmissionOn ? orangeEmission : Color.black);
        SetEmissionForGroup(redObjects, isEmissionOn ? redEmission : Color.black);
    }

    private void SetEmissionForGroup(Renderer[] renderers, Color color)
    {
        foreach (var rend in renderers)
        {
            if (rend == null) continue;

            var material = rend.material;
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", color);
        }
    }
}
