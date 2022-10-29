using Godot;
using System;

public class MainGame : Spatial
{
    PackedScene Lavalamp;
    bool made = false;
    int loops = 10;
    public override void _Ready()
    {
        Lavalamp = (PackedScene)ResourceLoader.Load("res://LavaLamp.tscn");
        int radius = 5;
        for (int i = 0; i < loops; i++)
        {
            float numOfScenes = (float)(2.0f * Mathf.Pi * i);
            float theta = Mathf.Pi * (2.0f) / (numOfScenes);
            for (int j = 0; j < numOfScenes; j++)
            {
                float angle = j * theta;
                float x = (radius) * Mathf.Cos(angle) * i;
                float y = (radius) * Mathf.Sin(angle) * i;
                MeshInstance LLMPInst = Lavalamp.Instance<MeshInstance>();
                LLMPInst.Translation = new Vector3(x, y, 0);
                AddChild(LLMPInst);
            }
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }
}
