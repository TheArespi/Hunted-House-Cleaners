using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedByDepth : MonoBehaviour
{
    public float offset = 0f;
    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y + offset);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        float lineSize = transform. right.x - transform.position.x;

        Gizmos.DrawLine(
            new Vector2(transform.position.x - lineSize / 2, transform.position.y + offset),
            new Vector2(transform.position.x + lineSize / 2, transform.position.y + offset)
        );
    }
}
