using Godot;
using System;

public partial class EnemyRangeAI : EnemyAI
{
    
    bool playerInRange = false;
    [Export] public PackedScene ExplosionScene;

    public override void findAndMoveToPlayer(Vector2 playerPosition)
    { 
        if (playerInRange == false)
        {
            base.findAndMoveToPlayer(playerPosition);
        }
        else
        {
            Velocity = Vector2.Zero;
        }
    }

    private void OnBodyEntered(CharacterBody2D body)
    {
        GD.Print($"Body entered: {body.Name}");
        playerInRange = true;
    }

    private void OnBodyExited(CharacterBody2D body)
    {
        GD.Print($"Body exited: {body.Name}");
        playerInRange = false;
    }

    private PackedScene packedScene;
    private void attack()
    {
        GD.Print("Attack"); 
        Node instance = ExplosionScene.Instantiate();
        AddChild(instance);
    }
}