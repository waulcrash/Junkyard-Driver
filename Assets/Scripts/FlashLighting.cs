using UnityEngine;

public class FlashLighting : MonoBehaviour
{
    private Light FlashLight;
  

    void Start()
    {
        FlashLight = GetComponent<Light>();
       FlashLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           
            FlashLight.enabled = !FlashLight.enabled;
        }
    }
}
