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
    bool isVR = false;
    ARVRController RightController;
    ARVRController LeftController;
    float VRRotateAmount = 0.5f;

    public float Gravity = 9.8f;
    ARVRCamera VRCam;
    public override void _Ready()
    {
        VRCam = GetNode<ARVRCamera>("ARVROrigin/ARVRCamera");
        var vr = ARVRServer.FindInterface("OpenVR");
        if (vr != null && vr.Initialize())
        {
            GetViewport().Arvr = true;

            OS.VsyncEnabled = false;
            Engine.TargetFps = 90;
            isVR = true;
        }
        // reference to the player node
        if (isVR)
        {
            VRCam.Current = true;
        }
        else
        {
            GetNode<Camera>("PlayerCam").Current = true;
        }
        Input.MouseMode = Input.MouseModeEnum.Captured;
        RotationDegrees = VRCam.RotationDegrees;

    }

    public override void _PhysicsProcess(float delta)
    {
        Movement(delta);
    }


    public void Movement(float delta)
    {
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

    private void _on_Right_button_pressed(int button)
    {
        if (button == 15)
        {
            RotateY(-VRRotateAmount);
            VRCam.RotationDegrees = RotationDegrees;
        }
    }
    private void _on_Left_button_pressed(int button)
    {
        if (button == 15)
        {
            RotateY(VRRotateAmount);
            VRCam.RotationDegrees = RotationDegrees;
        }
    }
}
