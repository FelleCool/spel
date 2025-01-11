using Godot;
using System;

public partial class test : Node
{

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("test")) // Om attack-knappen trycks
        {
			foreach (Node child in GetChildren())
		{
    		GD.Print("Child: ", child.Name);
		}
		}
	}
}
