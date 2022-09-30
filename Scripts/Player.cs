using Godot;
using System;
using System.Linq;

public class Player : KinematicBody2D
{
	public Vector2 velocity = new Vector2();
	public Area2D crystal;
	
	
	
	public override void _Ready()
	{
		crystal = GetNode<Area2D>("/root/Node2D/crystal");
	}
	
	public override void _Process(float delta)
	{
	
		var allEnemies = GetTree().GetNodesInGroup("Enemy");
		var min_distance = 99999f;
		EnemyScene min_enemy = null;
		
		foreach (var enemy in allEnemies.OfType<EnemyScene>())
		{
			var distance = crystal.Position.DistanceTo(enemy.GlobalPosition);
			
			if (distance < min_distance)
			{
				min_distance = distance;
				min_enemy = enemy;
				

			}
		}

		if(min_enemy != null) LookAt(min_enemy.Position);
		
	}
}

