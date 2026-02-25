using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private float _castDistance;
    [SerializeField] private LayerMask _groundLayer;
    public bool CheckIsGround()
    {
        if(Physics2D.BoxCast(transform.position, _boxSize, 0, -transform.up, _castDistance, _groundLayer))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * _castDistance, _boxSize);
    }
}
