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

    public async void FadeInTransition()
    {
        // if fade isn't happening and a fade in transition is requested, fade in animation starts after small delay
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
        // if fade isn't happening and a fade out transition is requested, fade out animation starts after small delay
        if (!fadeOutHappened)
        {
            fadeInHappened = true;
            await ToSignal(GetTree().CreateTimer(2), "timeout");
            transitionPlayer = GetNode<AnimationPlayer>("%TransitionManager");
            transitionPlayer.CurrentAnimation = "TransitionOut";
        }
    }
}
