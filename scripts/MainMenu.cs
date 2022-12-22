using Godot;
using System;

public class MainMenu : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    AnimationPlayer transitionPlayer;

    private void _on_Flatscreen_pressed()
    {
        transitionPlayer = GetNode<AnimationPlayer>("%TransitionManager");
        transitionPlayer.CurrentAnimation = "TransitionOut";
        GetTree().ChangeScene("res://scenes/MainGame.tscn");
    }
}
