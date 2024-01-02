using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public SpriteRenderer spriteRenderer;

    private bool _pressing_up = false;
    private bool _pressing_right = false;
    private bool _pressing_left = false;
    private bool _pressing_down = false;

    //interfaces
    public void moveUp() => _pressing_up = true;
    public void stopUp() => _pressing_up = false;

    public void moveRight() => _pressing_right = true;
    public void stopRight() => _pressing_right = false;

    public void moveLeft() => _pressing_left = true;
    public void stopLeft() => _pressing_left = false;

    public void moveDown() => _pressing_down = true;
    public void stopDown() => _pressing_down = false;

    private void Update()
    {
        Vector2 newPosition = transform.position;

        if (_pressing_up && !_pressing_down)
            newPosition += new Vector2(0, speed * Time.deltaTime);
        else if (!_pressing_up && _pressing_down)
            newPosition += new Vector2(0, speed * Time.deltaTime * -1);

        if (_pressing_left && !_pressing_right)
        {
            newPosition += new Vector2(speed * Time.deltaTime * -1, 0);
            spriteRenderer.flipX = true;
        }
        else if (!_pressing_left && _pressing_right)
        {
            newPosition += new Vector2(speed * Time.deltaTime, 0);
            spriteRenderer.flipX = false;
        }

        transform.position = newPosition;
    }
}
