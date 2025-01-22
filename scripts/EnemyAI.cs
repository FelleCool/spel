using Godot;
using System;

public partial class EnemyAI : CharacterBody2D
{
    [Export] public float Speed = 100f; // Fiendens rörelsehastighet
    [Export] public float hp = 100;
		

    public override void _Ready()
    {
        AddToGroup("fiender");
    }
    public void findAndMoveToPlayer(Vector2 playerPosition)
    {
        Vector2 player = playerPosition;

        // Beräkna riktningen mot spelaren
        Vector2 direction = (player - GlobalPosition).Normalized();

        // Flytta mot spelaren
        Velocity = direction * Speed;
    }

    public override void _PhysicsProcess(double delta)
    {
        // Använd MoveAndSlide för rörelse
        MoveAndSlide();
    }
}