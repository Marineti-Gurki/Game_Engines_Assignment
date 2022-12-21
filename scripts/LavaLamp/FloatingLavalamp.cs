using Godot;
using System;

public class FloatingLavalamp : MeshInstance
{
    Vector3 CurrentPosition;
    [Export] public float Amplitude = 1.1f;
    float Frequency = 1.1f;
    float TimeScale = 0.1f;
    float Theta;
    bool WithinArea = false;
    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ActionConfirm") && WithinArea)
        {
            Hide();
            GetTree().ChangeScene("res://scenes/PreGame.tscn"); //Buggy, creates a bunch of debugger errors.
        }
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

    private void _on_Area_body_entered(object body)
    {
        WithinArea = true;
    }
    private void _on_Area_body_exited(object body)
    {
        WithinArea = false;
    }
}
