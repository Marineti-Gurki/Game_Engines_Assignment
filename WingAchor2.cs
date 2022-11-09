using Godot;
using System;

public class WingAchor2 : Spatial
{
    float RotAmount = -195;
    bool clockwise = false;
    Tween tween;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animator();
        RotationDegrees = new Vector3(0, 0, -180);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    private void _on_TweenAnc2_tween_all_completed()
    {
        animator();
        if (clockwise)
        {
            RotAmount = -195;
            clockwise = false;
        }
        else
        {
            RotAmount = -165;
            clockwise = true;
        }
        tween.Start();
    }

    public void animator()
    {
        tween = (Tween)GetNode<Tween>("%TweenAnc2");
        tween.InterpolateProperty(this, "rotation_degrees", RotationDegrees, new Vector3(0, 0, RotAmount), 0.5f, Tween.TransitionType.Sine, Tween.EaseType.InOut);
        GD.Print(RotationDegrees);
        tween.Start();
    }
}
