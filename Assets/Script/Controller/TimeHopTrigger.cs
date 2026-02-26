using UnityEngine;

public class TimeHopTrigger : MonoBehaviour
{
    [SerializeField] private TimeSystem timeSystem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timeSystem.AdvanceTime();
        }
    }
}