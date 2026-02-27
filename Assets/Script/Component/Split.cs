using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    [SerializeField] private GameObject splitPrefab;
    [SerializeField] private int splitCount = 2;
    [SerializeField] private float spawnOffset = 0.5f;
    [SerializeField] private float spawnForce = 3f;

    public void HandleSplit()
    {
        if (splitPrefab == null) return;

        for (int i = 0; i < splitCount; i++)
        {
            Vector2 offset = Random.insideUnitCircle.normalized * spawnOffset;
            GameObject clone = Instantiate(splitPrefab, (Vector2)transform.position + offset, Quaternion.identity);

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(offset.normalized * spawnForce, ForceMode2D.Impulse);
            }
        }
    }
}
