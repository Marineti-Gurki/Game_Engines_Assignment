using Godot;
using System;

public class PlayerCam : Camera
{

    KinematicBody player;
    InputEvent InputEventTracker;

    [Export] float MouseSensitivity = 0.10f;
    public override void _Ready()
    {
        player = GetNode<KinematicBody>($"..");
    }

    public override void _Input(InputEvent inputEvent)
    {
        Aim(inputEvent);
    }

    public void Aim(InputEvent inputEvent)
    {
        var mouseMotion = inputEvent as InputEventMouseMotion;
        if (mouseMotion != null)
        {
            if (Input.MouseMode == Input.MouseModeEnum.Captured)
            {

                Vector3 currentPitch = player.RotationDegrees;
                currentPitch.y -= mouseMotion.Relative.x * MouseSensitivity;
                // player.SetRotationDegrees(currentPitch);
                player.RotationDegrees = currentPitch;

                Vector3 currentTilt = RotationDegrees;//grab current rotation of camera.
                currentTilt.x -= mouseMotion.Relative.y * MouseSensitivity;                                 //change the current rotation by the relative mouse coor change on the y Axis
                currentTilt.x = Mathf.Clamp(currentTilt.x, -90, 90);                                        //clamp the rotation to -90 and 90 so that you cant become possessed.
                                                                                                            // GetNode<Camera>("Camera").SetRotationDegrees(currentTilt); 		//sets the rotation of the camera to the new value
                RotationDegrees = currentTilt;        //sets the rotation of the camera to the new value

            }
        }
    }
}
