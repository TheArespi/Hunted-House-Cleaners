using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public float speed;
    private void Update()
    {
        Vector2 newPosition = Vector2.Lerp(transform.position, target.transform.position, speed);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
