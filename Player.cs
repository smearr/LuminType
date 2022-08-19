using Godot;
using System;
using System.Linq;

public class Player : KinematicBody2D
{
	public Vector2 velocity = new Vector2();
	
	public override void _Ready()
	{
	}
	
	public override void _Process(float delta)
	{
	
		var allEnemies = GetTree().GetNodesInGroup("Enemy");
		var min_distance = 99999f;
		EnemyScene min_enemy = null;
		
		foreach (var enemy in allEnemies.OfType<EnemyScene>())
		{
			var distance = Position.DistanceTo(enemy.Position);
			
			if (distance < min_distance)
			{
				min_distance = distance;
				min_enemy = enemy;
			}
		}

		if(min_enemy != null) LookAt(min_enemy.Position);
		
		velocity = Position.DirectionTo(Global.pos) * 3000;
		if (Position.DistanceTo(Global.pos) > 5)
		{
			velocity = MoveAndSlide(velocity);
		}
	}
}
