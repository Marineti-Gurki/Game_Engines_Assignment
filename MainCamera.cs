using Godot;
using System;

public class MainCamera : Camera
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] MeshInstance TrackedObject;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        TrackedObject = GetTree().Root.GetNode<MeshInstance>("MainGame/Base/Glass");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        LookAt(TrackedObject.Translation, Vector3.Up);
    }
}
