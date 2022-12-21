using Godot;
using System;

public class Interact : Label3D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    private void _on_Area_body_entered(object body)
    {
        if (body is Player player)
        {
            Show();
        }
    }
    private void _on_Area_body_exited(object body)
    {
        if (body is Player player)
        {
            Hide();
        }
    }
}
