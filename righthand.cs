using Godot;
using System;

public class righthand : ARVRController
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        GD.Print("btn0 " + IsButtonPressed(0));
        GD.Print("btn1 " + IsButtonPressed(1));
        GD.Print("btn2 " + IsButtonPressed(2));
        GD.Print("btn3 " + IsButtonPressed(3));
        GD.Print("btn4 " + IsButtonPressed(4));
        GD.Print("btn5 " + IsButtonPressed(5));
        GD.Print("btn6 " + IsButtonPressed(6));
        GD.Print("btn7 " + IsButtonPressed(7));
        GD.Print("btn8 " + IsButtonPressed(8));
        GD.Print("btn9 " + IsButtonPressed(9));
        GD.Print("btn10 " + IsButtonPressed(10));
        GD.Print("btn11 " + IsButtonPressed(11));
        GD.Print("btn12 " + IsButtonPressed(12));
        GD.Print("btn13 " + IsButtonPressed(13));
    }
}
