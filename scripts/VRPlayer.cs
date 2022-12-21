using Godot;
using System;

public class VRPlayer : KinematicBody
{
    int moveSpeed;
    Vector3 jump = Vector3.Zero;
    int RunSpeed = 10;
    int MoveSpeed = 7;
    float JumpForce = 5;
    float Acceleration = 1.15f;
    float VRRotateAmount = 0.5f;
    public float Gravity = 9.8f;
    ARVRController RightController;
    ARVRController LeftController;
    public override void _Ready()
    {
        //Locks mouse within the screen
        Input.MouseMode = Input.MouseModeEnum.Captured;
        LeftController = GetNode<ARVRController>("ARVROrigin/Left");
        RightController = GetNode<ARVRController>("ARVROrigin/Right");
    }

    public override void _PhysicsProcess(float delta)
    {
        Movement(delta);
    }


    public void Movement(float delta)
    {
        // GD.Print(Input.GetJoyAxis(0, 1));
        //Movement code for the player.
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
        //Checks if sprinting
        if (Sprinting)
        {
            moveSpeed = RunSpeed;
        }
        else if (!Sprinting)
        {
            moveSpeed = MoveSpeed;
        }
        //checks if moving forward or backward
        if (Input.IsActionPressed("move_forward"))
        {
            direction -= Transform.basis.z;
        }
        else if (Input.IsActionPressed("move_backward"))
        {
            direction += Transform.basis.z;
        }
        //checks if moving left or right
        if (Input.IsActionPressed("move_left"))
        {
            direction2 -= Transform.basis.x;
        }
        else if (Input.IsActionPressed("move_right"))
        {
            direction2 += Transform.basis.x;
        }
        if (Input.IsActionJustPressed("rotate_left") && RightController.GetHand().Equals(ARVRPositionalTracker.TrackerHand.RightHand))
        {
            RotateY(-VRRotateAmount);
        }
        if (Input.IsActionJustPressed("rotate_right") && RightController.GetHand().Equals(ARVRPositionalTracker.TrackerHand.RightHand))
        {
            RotateY(VRRotateAmount);
        }


        MoveAndSlide(jump, Vector3.Up);
        //Ensures you can only jump once
        if (IsOnFloor() && !Jumping)
        {
            Jumping = false;
            //jump.y needs to be reset otherwise gravity accumulates forever.
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
        //adds gravity
        jump.y -= Gravity * delta;


        direction = direction + direction2;
        direction = direction.Normalized();

        velocity = direction * moveSpeed;
        velocity.LinearInterpolate(velocity, Acceleration * delta);
        MoveAndSlide(velocity, Vector3.Up);
    }

}
