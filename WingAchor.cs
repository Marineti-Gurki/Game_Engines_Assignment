using Godot;
using System;

public class WingAchor : Spatial
{
    float RotAmount = 15;
    Tween tween;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animator();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    private void _on_Tween_tween_all_completed()
    {
        animator();
        RotAmount *= -1;
        tween.Start();
    }

    public void animator()
    {
        tween = (Tween)GetNode<Tween>("%TweenAnc1");
        tween.InterpolateProperty(this, "rotation_degrees", RotationDegrees, new Vector3(0, 0, RotAmount), 0.5f, Tween.TransitionType.Sine, Tween.EaseType.InOut);
        tween.Start();
    }
}
