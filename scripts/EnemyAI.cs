using Godot;
using System;

public partial class EnemyAI : CharacterBody2D
{

    [Export] public float Speed = 100f; // Fiendens rörelsehastighet
    [Export] public float hp = 100;
		

    public override void _Ready(){
        AddToGroup("fiender");
        
    }
    public virtual void findAndMoveToPlayer(Vector2 playerPosition){
        Move(playerPosition);
        
    }
    private void Move(Vector2 playerPosition){
        // Beräkna riktningen mot spelaren
        Vector2 direction = (playerPosition - GlobalPosition).Normalized();

        // Flytta mot spelaren
        Velocity = direction * Speed;
    }
    public void TakeDamage(int damage){

        hp -= damage;
        GD.Print($"Enemy took {damage} damage! Remaining health: {hp}");
    

        if (hp <= 0)
        {
            Die();
        }
    }
    private void Die(){
        GD.Print($"{Name} died!");
        QueueFree(); // Tar bort fienden från spelet
    }
    public override void _PhysicsProcess(double delta){
        // Använd MoveAndSlide för rörelse
        MoveAndSlide();
    }
}