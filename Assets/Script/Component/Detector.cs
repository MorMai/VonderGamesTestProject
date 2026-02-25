using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private LayerMask _playerLayer; // Set this to layer that you want to detect

    public Transform CurrentTarget { get; private set; }
    public bool IsPlayerDetected => CurrentTarget != null;

    private void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _detectionRadius, _playerLayer);

        if (hit != null)
        {
            CurrentTarget = hit.transform;
        }
        else
        {
            CurrentTarget = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}