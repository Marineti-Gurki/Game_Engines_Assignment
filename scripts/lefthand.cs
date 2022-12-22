using Godot;
using System;

public class lefthand : ARVRController
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var vr = ARVRServer.FindInterface("OpenVR");
        if (vr != null && vr.Initialize())
        {
            GetViewport().Arvr = true;

            OS.VsyncEnabled = false;
            Engine.TargetFps = 90;
        }
        else
        {
            Hide();
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }
}
