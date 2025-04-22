using Godot;
using System.Collections.Generic;

public partial class SwordAttack : Area2D
{
    private int AttackDamage = 25;
    private Timer attack;
    private List<CharacterBody2D> enemiesInArea = new List<CharacterBody2D>(); // Lista för fiender

    public override void _Ready()
    {
        // Hämta Timer-noden från scenen
        attack = GetNode<Timer>("attack");
    }

    private void OnBodyEntered(CharacterBody2D body)
    {
        GD.Print($"Body entered: {body.Name}");
        if (body.Name != "Player"){
            enemiesInArea.Add(body);
        }
    }

    private void OnBodyExited(CharacterBody2D body)
    {
        GD.Print($"Body exited: {body.Name}");

        enemiesInArea.Remove(body);
    }

    private void OnDamageTimerTimeout()
    {
        foreach (EnemyAI enemy in enemiesInArea){
             enemy.TakeDamage(AttackDamage);
        }

    }
}
