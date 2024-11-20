using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Hämta inputriktning och hantera rörelse/avstanning
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		// Uppdatera hastighet och spelares position
		Velocity = velocity;

		// Uppdatera spelarens position i GlobalData
		GlobalData globalData = (GlobalData)GetNode("/root/GlobalData"); 
		globalData.PlayerPosition = GlobalPosition;

		MoveAndSlide();
	}
}
