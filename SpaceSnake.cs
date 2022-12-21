using Godot;
using System;

public class SpaceSnake : Spatial
{
    Player player;
    float SnakeSpeed = 0.2f;
    Vector3 CurrentRotationInner;
    Vector3 CurrentRotationOuter;
    float Frequency = 1.1f;
    float TimeScale = 0.1f;
    float Theta;

    float Amplitude = 20f;

    public override void _Ready()
    {
        player = (Player)GetNode("%Player");
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
                CurrentRotationOuter.x = Angle * i;
                CurrentRotationOuter.x = Mathf.Lerp(RotationDegrees.x, CurrentRotationOuter.x, TimeScale);
                snakePart.RotationDegrees = CurrentRotationOuter;
                RotationDegrees = new Vector3(Angle * 0.2f, 0, 0);
            }
        }
        LookAt(player.Translation, Vector3.Up);
        Translation += (player.Translation - Translation) * (delta * SnakeSpeed);

    }

}
