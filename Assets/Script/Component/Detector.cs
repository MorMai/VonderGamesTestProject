using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private string _targetTag = "Player"; // change to tag

    public Transform CurrentTarget { get; private set; }
    public bool IsTargetDetected => CurrentTarget != null;

    private void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);
        float closestDistance = Mathf.Infinity;
        Transform foundTarget = null;

        foreach (var hit in hits)
        {
            if (hit.CompareTag(_targetTag))
            {
                float distance = Vector2.Distance(transform.position, hit.transform.position);

                if (distance < closestDistance) // check if this target is closer than the previously found target
                {
                    closestDistance = distance;
                    foundTarget = hit.transform;
                }

                foundTarget = hit.transform;
                break; 
            }
        }

        CurrentTarget = foundTarget;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}