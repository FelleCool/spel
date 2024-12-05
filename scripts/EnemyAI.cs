using Godot;
using System;

public partial class EnemyAI : CharacterBody2D
{
    [Export] public float Speed = 100f; // Fiendens rörelsehastighet
    [Export] public CharacterBody2D Player; // Referens till spelaren

    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Player == null)
            return;

        // Beräkna riktningen mot spelaren
        Vector2 direction = (Player.GlobalPosition - GlobalPosition).Normalized();

        // Flytta mot spelaren
        Velocity = direction * Speed;

        // Använd MoveAndSlide för rörelse
        MoveAndSlide();
    }
}