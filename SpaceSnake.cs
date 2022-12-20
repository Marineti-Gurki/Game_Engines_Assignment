using Godot;
using System;

public class SpaceSnake : Spatial
{
    Vector3 CurrentRotationInner;
    Vector3 CurrentRotationOuter;
    float Frequency = 1.1f;
    float TimeScale = 0.5f;
    float Theta;

    float Amplitude = 20f;

    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        Theta = Time.GetTicksMsec() * (Frequency * TimeScale * delta);
        float Angle = Amplitude * Mathf.Sin(Theta);
        for (int i = 0; i < GetChildCount(); i++)
        {
            var snakePart = (Spatial)GetChild(i);

            if (snakePart.Name != "Body")
            {
                CurrentRotationOuter = snakePart.RotationDegrees;
                CurrentRotationOuter.z = Angle * i;
                CurrentRotationOuter.z = Mathf.Lerp(RotationDegrees.z, CurrentRotationOuter.z, TimeScale);
                snakePart.RotationDegrees = CurrentRotationOuter;

                // for (int j = 0; j < GetChildCount(); j++)
                // {
                //     var snakePart2 = (Spatial)GetChild(j);
                //     CurrentRotationInner = snakePart2.RotationDegrees;

                //     CurrentRotationInner.z = Angle * i;
                //     CurrentRotationInner.z = Mathf.Lerp(RotationDegrees.z, CurrentRotationInner.z, TimeScale * 0.1f);
                //     snakePart.RotationDegrees = CurrentRotationInner;
                // }
            }
        }
    }

}
