using UnityEngine;

public class EnableEmission : MonoBehaviour
{
   
   
    public Renderer[] yellowObjects;
    public Color yellowEmission = Color.yellow;

   
    public Renderer[] orangeObjects;
    public Color orangeEmission = new Color(1f, 0.5f, 0f); // Оранжевый

    
    public Renderer[] redObjects;
    public Color redEmission = Color.red;

    private bool isEmissionOn = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isEmissionOn = !isEmissionOn;
            UpdateAllEmission();
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
