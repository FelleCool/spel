using Godot;
using System;

public partial class EnemySpawner : Node2D
{
	// En referens till fiende-scenen
	private PackedScene _enemyScene;

	public override void _Ready()
	{
		// Ladda in fiende-scenen
		_enemyScene = (PackedScene)GD.Load("res://scenes/enemy.tscn");

		// Spawna en fiende direkt när spelet startar, eller kalla på denna funktion när du vill spawna fienden
		SpawnEnemy(new Vector2(200, 200)); // Sätter fienden på positionen (200, 200)
	}

	private void SpawnEnemy(Vector2 position)
	{
		// Instansiera en ny fiende från scenen
		var enemyInstance = (Node2D)_enemyScene.Instantiate();
		
		// Sätt positionen där du vill spawna fienden
		enemyInstance.Position = position;

		// Lägg till fienden som barn till Main-scenen (eller en annan scen du vill använda)
		AddChild(enemyInstance);
	}
}
