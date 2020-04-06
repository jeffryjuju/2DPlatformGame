using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the inputs for the player movement.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool isJump = false;
    bool isCrouch = false;
    
    // Update is called once per frame
    void Update()
    {
        // Used to get left/right input value (left = A/left arrow key, right = D/right arrow key)
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Used to check the jump button (button = space / up arrow key)
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }

        // Used to check the crouch button (button = s / down arrow key)
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouch = true;
        }else if (Input.GetButtonUp("Crouch")) // if crouch button is released..
        {
            isCrouch = false;
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouch, isJump);
        isJump = false; // immediately change isJump state to false so that the character won't jump forever
    }
}
