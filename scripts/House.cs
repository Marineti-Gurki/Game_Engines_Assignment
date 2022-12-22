using Godot;
using System;

public class House : Spatial
{
    bool inActionArea = false;

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ActionConfirm") && inActionArea)
        {
            GetTree().ChangeScene("res://scenes/MainGame.tscn");
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

    private void _on_Left_button_pressed(int button)
    {
        if (button == 1 && inActionArea)
        {
            GetTree().ChangeScene("res://scenes/MainGame.tscn");
        }
    }
    private void _on_Right_button_pressed(int button)
    {
        if (button == 1 && inActionArea)
        {
            GetTree().ChangeScene("res://scenes/MainGame.tscn");
        }
    }
}
