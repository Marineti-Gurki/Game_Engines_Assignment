using Godot;
using System;

public class FlyPath : PathFollow
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    float flyspeed = 10;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RotationMode = RotationModeEnum.Oriented;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Offset = Offset + flyspeed * delta;
    }
}
