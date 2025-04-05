using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarControl : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private Transform centerOfMass;
    [SerializeField] private Wheel[] wheels;

    [SerializeField] private int motorForce;
    [SerializeField] private int breakForce;

    private float vInput;
    private float hInput;
    private float breakInput;

    private float speed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.centerOfMass = centerOfMass.position;
    }

    void Update()
    {
        speed = rigidBody.linearVelocity.magnitude;

        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.linearVelocity);

        breakInput = (forwardSpeed < -0.5f && vInput > 0) || (forwardSpeed > 0.5f && vInput < 0) ? Mathf.Abs(vInput) : 0;

        

        foreach (Wheel wheel in wheels)
        {

            wheel.wheelCollider.motorTorque = motorForce * vInput;
                        
            wheel.UpdateMeshPosition();

            if (wheel.isForward)
            {
                wheel.wheelCollider.steerAngle = hInput * 30;
                
            }

            wheel.wheelCollider.brakeTorque = breakForce * breakInput * (wheel.isForward ? 0.7f : 0.3f);
            
        }
    }
}