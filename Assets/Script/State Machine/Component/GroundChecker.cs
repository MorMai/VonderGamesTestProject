using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    public bool CheckIsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //visualize the check
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}