using Godot;
using System;

public class House : Spatial
{
    bool inActionArea = false;
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ActionConfirm") && inActionArea)
        {
            GetTree().ChangeScene("res://scenes/MainGame.tscn"); //Buggy, creates a bunch of debugger errors.
        }
    }

    public void _on_Area_body_entered(object body)
    {
        if (body is Player player)
        {
            inActionArea = true;

        }
    }
    public void _on_Area_body_exited(object body)
    {
        if (body is Player player)
        {
            inActionArea = false;
        }
    }
}
