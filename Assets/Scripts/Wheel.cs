using UnityEngine;

[System.Serializable]
public struct Wheel
{
    public Transform wheelMesh;
    public WheelCollider wheelCollider;
    public bool isForward;

    public void UpdateMeshPosition()
    {
        Vector3 position;
        Quaternion rotation;
        
        wheelCollider.GetWorldPose(out position, out rotation);

        wheelMesh.position = position;
        wheelMesh.rotation = rotation;
    }
}
