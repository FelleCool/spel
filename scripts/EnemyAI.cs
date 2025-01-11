using Godot;
using System;

public partial class EnemyAI : CharacterBody2D
{
    [Export] public float Speed = 100f; // Fiendens rörelsehastighet
    
    // Uppdatera spelarens position i GlobalData
		

    public override void _Ready()
    {
        
    }
    private void findAndMoveToPlayer(){
         GlobalData globalData = (GlobalData)GetNode("/root/GlobalData"); 
		Vector2 player = globalData.PlayerPosition;

        // Beräkna riktningen mot spelaren
        Vector2 direction = (player - GlobalPosition).Normalized();

        // Flytta mot spelaren
        Velocity = direction * Speed;
    }

    private void Attack(){
        
    }

    public override void _PhysicsProcess(double delta)
    {
       findAndMoveToPlayer();
        // Använd MoveAndSlide för rörelse
        MoveAndSlide();
    }
}