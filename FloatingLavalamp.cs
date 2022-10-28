using Godot;
using System;

public class FloatingLavalamp : MeshInstance
{
    Vector3 CurrentPosition;
    [Export] public float Amplitude = 1.1f;
    float Frequency = 1.1f;
    float TimeScale = 0.1f;
    float Theta;
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        Theta = Time.GetTicksMsec() * (Frequency * TimeScale * delta);
        float Angle = Amplitude * Mathf.Sin(Theta);
        CurrentPosition = Translation;
        CurrentPosition.y = Angle + 3.5f;
        CurrentPosition.y = Mathf.Lerp(Translation.y, CurrentPosition.y, TimeScale);
        Translation = CurrentPosition;
    }
}
