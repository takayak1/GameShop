using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    private float currentYaw = 0f;
    private float fixedPitch = 0f;           
    private float currentDistance = 0f;

    void LateUpdate()
    {
        if (target == null) return;
        
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            currentYaw += mouseX * rotationSpeed;
        }
        
        currentDistance = Mathf.Clamp(currentDistance, minZoom, maxZoom);
        
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(fixedPitch, currentYaw, 0f);
        Vector3 direction = rotation * Vector3.back;

        transform.position = target.position + direction * currentDistance;
        transform.LookAt(target.position);
    }
}