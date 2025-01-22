using Godot;
using System.Collections.Generic;
using System;

public partial class SwordAttack : Area2D
{
	int AttackDamage = 25;

    // Lista över fiender inom attackområdet
    List<CharacterBody2D> skib = new List<CharacterBody2D>();
    public override void _Ready()
    {
    }

    private void OnBodyEntered(Node body)
    {
        if()
        {
			skib.Add();
        }
    }

    private void OnBodyExited(Node body)
    {
        if()
        {
           skib.Remove(enemy);
        }
    }

    public void Attack()
    {
        foreach (var enemy in _enemiesInRange)
        {
            enemy.TakeDamage(AttackDamage);
        }
    }
}
