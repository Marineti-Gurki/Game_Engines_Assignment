using Godot;
using System;

public class MainMenu : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    AnimationPlayer transitionPlayer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }
    private void _on_Exit_pressed()
    {

    }
    private void _on_Settings_pressed()
    {

    }
    private void _on_VR_pressed()
    {

    }
    private void _on_Flatscreen_pressed()
    {
        transitionPlayer = GetNode<AnimationPlayer>("%TransitionManager");
        transitionPlayer.CurrentAnimation = "TransitionOut";
        GetTree().ChangeScene("res://scenes/MainGame.tscn");
    }
}
