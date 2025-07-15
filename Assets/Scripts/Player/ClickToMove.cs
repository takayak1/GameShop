using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent agent;

    [Header("Маркер")]
    public GameObject MarkerPrefab;
    public float markerLifetime = 2f;
    
    private GameObject currentMarker;
    private Vector3 targetPosition;
    private bool hasTarget = false;
    private float stopThreshold = 0.1f;
    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    agent.SetDestination(hit.point);
                    targetPosition = hit.point;
                    hasTarget = true;

                    ShowClickMarker(hit.point);
                }
            }
        }

        if (hasTarget && agent.remainingDistance <= stopThreshold && !agent.pathPending)
        {
            if (currentMarker != null)
            {
                Destroy(currentMarker);
            }

            hasTarget = false;
        }
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    void ShowClickMarker(Vector3 position)
    {
        if (currentMarker != null)
        {
            Destroy(currentMarker, markerLifetime);
        }

        if (MarkerPrefab != null)
        {
            currentMarker = Instantiate(MarkerPrefab, position + Vector3.up * 0.01f, Quaternion.identity);
        }
    }
}