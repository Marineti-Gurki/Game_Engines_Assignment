using Godot;
using System;

public class SpaceSnake : Spatial
{
    VRPlayer vrplayer;
    Player player;
    float SnakeSpeed = 0.2f;
    Vector3 CurrentRotationInner;
    Vector3 CurrentRotationOuter;
    float Frequency = 1.1f;
    float TimeScale = 0.1f;
    float Theta;
    bool isVR = false;

    float Amplitude = 20f;

    public override void _Ready()
    {
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
            vrplayer = (VRPlayer)GetNode("%VRPlayer");
        }
        else
        {
            player = (Player)GetNode("%Player");
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        // calculating Sin wave for the snakes movement
        Theta = Time.GetTicksMsec() * (Frequency * TimeScale * delta);
        float Angle = Amplitude * Mathf.Sin(Theta);
        for (int i = 0; i < GetChildCount(); i++)
        {
            var snakePart = (Spatial)GetChild(i);

            if (snakePart.Name != "Body")
            {
                CurrentRotationOuter = snakePart.RotationDegrees;
                CurrentRotationOuter.x = Angle * i;
                CurrentRotationOuter.x = Mathf.Lerp(RotationDegrees.x, CurrentRotationOuter.x, TimeScale);
                snakePart.RotationDegrees = CurrentRotationOuter;
                RotationDegrees = new Vector3(Angle * 0.2f, 0, 0);
            }
        }

        if (isVR)
        {
            // Rotates the snake to look at the player.
            LookAt(vrplayer.Translation, Vector3.Up);
            //Moves the snake towards the player
            Translation += (vrplayer.Translation - Translation) * (delta * SnakeSpeed);
        }
        else
        {
            // Rotates the snake to look at the player.
            LookAt(player.Translation, Vector3.Up);
            //Moves the snake towards the player
            Translation += (player.Translation - Translation) * (delta * SnakeSpeed);
        }

    }

    private void _on_Area_body_entered(object body)
    {
        //if the snake touches the player, game over
        if (body is Player plyr || body is VRPlayer vrplyr)
        {
            GetTree().Quit();
        }
    }

}
