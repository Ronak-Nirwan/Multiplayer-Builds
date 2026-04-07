using UnityEngine;

/// <summary>
/// Controls and calculate the overall movement related to character 
/// </summary>

public class CharacterMovement : IMovement
{
    private CharacterController controller;
    private float speed;
    private float sprintMultiplier;

    private float yVelocity;
    private float gravity = -9.8f;
    private float jumpForce = 2f;


    /// <summary>
    /// Constructor for implementing the controls and speed directly using it
    /// </summary>
    /// <param name="controller"> Reference to the character controller component </param>
    /// <param name="speed">The regular movement speed</param>
    /// <param name="sprintMultiplier"> The multiple for speed during spirinting </param>
    public CharacterMovement(CharacterController controller, float speed, float sprintMultiplier)
    {
        this.controller = controller;
        this.speed = speed;
        this.sprintMultiplier = sprintMultiplier;
    }

    /// <summary>
    /// Calculates the movement and switches for walking and sprinting
    /// </summary>

    public void Move(Vector2 input, bool isSprinting)
    {
        float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;

        Vector3 move = controller.transform.right * input.x +
                       controller.transform.forward * input.y;

        if (controller.isGrounded && yVelocity < 0)
            yVelocity = -2f;

        yVelocity += gravity * Time.deltaTime;

        Vector3 finalMove = move * currentSpeed + Vector3.up * yVelocity;

        controller.Move(finalMove * Time.deltaTime);
    }

    /// <summary>
    /// Calculations for jump
    /// </summary>

    public void Jump()
    {
        if (controller.isGrounded)
        {
            yVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
}