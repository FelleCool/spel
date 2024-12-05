using Godot;
using System;

public partial class EnemySpawner : Node2D
{
    [Export] public PackedScene EnemyScene; // Referens till fiende-scen
    [Export] public float SpawnRadius = 300f; // Maxavstånd för spawn-punkter
    [Export] public int SpawnCount = 5; // Antal fiender att spawna per gång
    [Export] public float SpawnInterval = 2f; // Tid mellan spawn-cykler
    [Export] public CharacterBody2D Player;

    private Timer spawnTimer; // Timer för att hantera spawn-intervall

    
public override void _Ready()
{
    if (Player == null)
    {
        GD.PrintErr("Spelare hittades inte!");
        return;
    }

    spawnTimer = new Timer();
    spawnTimer.WaitTime = SpawnInterval;
    spawnTimer.OneShot = false;
    spawnTimer.Connect("timeout", new Callable(this, nameof(SpawnEnemies)));
    AddChild(spawnTimer);
    spawnTimer.Start();
}


    private void SpawnEnemies()
    {
        if (EnemyScene == null)
        {
            GD.PrintErr("EnemyScene saknas");
            return;
        }

        for (int i = 0; i < SpawnCount; i++)
        {
            // Beräkna en slumpmässig position runt spelaren
            Vector2 spawnPosition = Player.GlobalPosition + GetRandomPointInRadius(SpawnRadius);

            // skapar fienden
            CharacterBody2D enemy = (CharacterBody2D)EnemyScene.Instantiate();
            enemy.GlobalPosition = spawnPosition;

            // Lägg till fienden i scenen
            GetParent().AddChild(enemy);
        }
    }

    private Vector2 GetRandomPointInRadius(float radius)
    {
        // Generera en slumpmässig vinkel och avstånd inom cirkeln
        float angle = (float)GD.RandRange(0, 2 * Math.PI);
        float distance = (float)GD.RandRange(0, radius);
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;
    }
}