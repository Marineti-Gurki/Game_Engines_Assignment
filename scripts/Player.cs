using Godot;
using System;

public class Player : KinematicBody
{
    int moveSpeed;
    Vector3 jump = Vector3.Zero;
    int RunSpeed = 10;
    int MoveSpeed = 7;
    float JumpForce = 5;
    float Acceleration = 1.15f;

    public float Gravity = 9.8f;
    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.

    public override void _PhysicsProcess(float delta)
    {
        Movement(delta);
    }


    public void Movement(float delta)
    {

        Vector3 velocity = Vector3.Zero;
        Vector3 direction = Vector3.Zero;
        Vector3 direction2 = Vector3.Zero;
        bool Sprinting = false;
        bool Jumping = false;

        if (Input.IsActionPressed("modifier_shift"))
        {
            Sprinting = true;
        }
        else
        {
            Sprinting = false;
        }
        if (Sprinting)
        {
            moveSpeed = RunSpeed;
        }
        else if (!Sprinting)
        {
            moveSpeed = MoveSpeed;
        }
        if (Input.IsActionPressed("move_forward"))
        {
            direction -= Transform.basis.z;
        }
        else if (Input.IsActionPressed("move_backward"))
        {
            direction += Transform.basis.z;
        }
        if (Input.IsActionPressed("move_left"))
        {
            direction2 -= Transform.basis.x;
        }
        else if (Input.IsActionPressed("move_right"))
        {
            direction2 += Transform.basis.x;
        }


        MoveAndSlide(jump, Vector3.Up);
        if (IsOnFloor() && !Jumping)
        {
            Jumping = false;
            jump.y = 0;
        }
        if (Input.IsActionPressed("jump"))
        {
            Jumping = true;
        }
        if (Jumping && IsOnFloor())
        {
            jump.y = JumpForce;
        }
        jump.y -= Gravity * delta;


        direction = direction + direction2;
        direction = direction.Normalized();

        velocity = direction * moveSpeed;
        velocity.LinearInterpolate(velocity, Acceleration * delta);
        MoveAndSlide(velocity, Vector3.Up);
    }

}
