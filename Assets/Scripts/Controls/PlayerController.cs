using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            playerMovement.moveUp();
        else if (Input.GetKeyUp(KeyCode.W))
            playerMovement.stopUp();

        if (Input.GetKeyDown(KeyCode.A))
            playerMovement.moveLeft();
        else if (Input.GetKeyUp(KeyCode.A))
            playerMovement.stopLeft();

        if (Input.GetKeyDown(KeyCode.D))
            playerMovement.moveRight();
        else if (Input.GetKeyUp(KeyCode.D))
            playerMovement.stopRight();

        if (Input.GetKeyDown(KeyCode.S))
            playerMovement.moveDown();
        else if (Input.GetKeyUp(KeyCode.S))
            playerMovement.stopDown();
    }
}
