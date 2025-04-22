using Godot;
using System.Collections.Generic;
using System;

public partial class Enemy_Spawner : Node2D
{
	private Timer spawner;
	[Export]
	public float radius;
	
	[Export]
    public Godot.Collections.Array<PackedScene> EnemyScenes { get; set; } = new Godot.Collections.Array<PackedScene>();
	
	public override void _Ready()
	{
		spawner = GetNode<Timer>("Spawner");
		spawner.Start();
	}
	
	public void Spawner(){
		GD.Print("Spawn");
		_rndEnemy();
	}

	Random rnd = new Random();
	private Vector2 _rndPoint(float spawn){
		float angle = (float)GD.RandRange(0, 2 * Math.PI);
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawn;
	}

	private void _rndEnemy(){
		int enemyIndex = rnd.Next(EnemyScenes.Count);
        PackedScene enemyScene = EnemyScenes[enemyIndex];
		Node2D enemyInstance = enemyScene.Instantiate<Node2D>();
		enemyInstance.GlobalPosition = _rndPoint(radius);
		GetParent().AddSibling(enemyInstance);
		
	}


}
