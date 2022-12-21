using Godot;
using System;

public class ScreenSwitch : ColorRect
{
    AnimationPlayer transitionPlayer;
    bool fadeInHappened = false;
    bool fadeOutHappened = false;
    public override void _Ready()
    {
        FadeInTransition();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }


    public async void FadeInTransition()
    {
        if (!fadeInHappened)
        {
            fadeInHappened = true;
            await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
            transitionPlayer = GetNode<AnimationPlayer>("%TransitionManager");
            transitionPlayer.CurrentAnimation = "Transition";
        }
    }
    public async void FadeOutTransition()
    {
        if (!fadeOutHappened)
        {
            fadeInHappened = true;
            await ToSignal(GetTree().CreateTimer(2), "timeout");
            transitionPlayer = GetNode<AnimationPlayer>("%TransitionManager");
            transitionPlayer.CurrentAnimation = "TransitionOut";
        }
    }
}
