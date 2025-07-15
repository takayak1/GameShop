using UnityEngine;

public class ZoomToObjectScroll : MonoBehaviour
{
    public Transform zoomTarget;

    [Header("Zoom")]
    public float zoomSpeed = 5f;
    public float minDistance = 2f;
    public float maxDistance = 15f;

    private float currentDistance = 5f;

    void Start()
    {
        if (zoomTarget != null)
        {
            currentDistance = Vector3.Distance(transform.position, zoomTarget.position);
        }
    }

    void LateUpdate()
    {
        if (zoomTarget == null) return;

        HandleScrollInput();
        UpdateCameraPosition();
    }

    private void HandleScrollInput()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0f)
        {
            currentDistance -= scroll * zoomSpeed;
            currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
        }
    }

    private void UpdateCameraPosition()
    {
        Vector3 direction = (transform.position - zoomTarget.position).normalized;
        transform.position = zoomTarget.position + direction * currentDistance;
        transform.LookAt(zoomTarget.position);
    }
}