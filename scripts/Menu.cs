using Godot;
using System;

public partial class Menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public void Play()
	{
        GetTree().ChangeSceneToFile("res://scenes/Game.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Exit()
	{
		GetTree().Quit();
	}
}
