using Godot;
using System;

public class righthand : ARVRController
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        GD.Print("axis2" + GetJoystickAxis(2));
        GD.Print("axis3" + GetJoystickAxis(3));
        GD.Print("axis4" + GetJoystickAxis(4));
    }
}