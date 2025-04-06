using UnityEngine;

public class FlashLighting : MonoBehaviour
{
    private Light FlashLight;

    void Start()
    {
        FlashLight = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlashLight.enabled = !FlashLight.enabled;
        }
    }
}
