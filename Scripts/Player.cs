using Godot;
using System;
using System.Linq;

public class Player : KinematicBody2D
{
	public Vector2 velocity = new Vector2();
	public Area2D crystal;
	public Sprite crosshair;
	
	
	
	public override void _Ready()
	{
		crystal = GetNode<Area2D>("/root/Node2D/crystal");
		crosshair = GetNode<Sprite>("Crosshair");
		
		if (Global.gameMode == "towerdefense")
		{
			Position = new Vector2(638, 750);
		}
		
		else if (Global.gameMode == "endless")
		{
			Position = new Vector2(1156, 150);
		}
	}
	
	public override void _Process(float delta)
	{
	
		var allEnemies = GetTree().GetNodesInGroup("Enemy");
		var min_distance = 99999f;
		var max_distance = 0f;
		EnemyScene min_enemy = null;
		EnemyScene max_enemy = null;
		
		foreach (var enemy in allEnemies.OfType<EnemyScene>())
		{
			if (Global.gameMode == "towerdefense")
			{
				var distance = crystal.Position.DistanceTo(enemy.GlobalPosition);
			
				if (distance < min_distance)
				{
					min_distance = distance;
					min_enemy = enemy;
					enemy.GetNode<Label>("Text").Modulate = new Color("00d5ff");
	
				}		
				
				if(min_enemy != null)
				{
					LookAt(min_enemy.Position);
					crosshair.GlobalPosition = min_enemy.Position;
				} 		
			}
			
			else if (Global.gameMode == "endless")
			{
				var distance = Position.DistanceTo(enemy.GlobalPosition);
				
				if (distance > max_distance)
				{
					max_distance = distance;
					max_enemy = enemy;
					enemy.GetNode<Label>("Text").Modulate = new Color("00d5ff");
				}
				
				if(max_enemy != null)
				{
					LookAt(max_enemy.Position);
					crosshair.GlobalPosition = max_enemy.Position;
				}
			}
		}	
	}
}

