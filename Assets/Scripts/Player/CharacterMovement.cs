using UnityEngine;

public class CharacterMovement : IMovement
{
    private CharacterController controller;
    private float speed;
    private float sprintMultiplier;

    private float yVelocity;
    private float gravity = -9.8f;
    private float jumpForce = 5f;

    public CharacterMovement(CharacterController controller, float speed, float sprintMultiplier)
    {
        this.controller = controller;
        this.speed = speed;
        this.sprintMultiplier = sprintMultiplier;
    }

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

    public void Jump()
    {
        if (controller.isGrounded)
        {
            yVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
}