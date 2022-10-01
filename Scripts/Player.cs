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
				enemy.GetNode<Label>("Text").Modulate = new Color("00d5ff");
				

			}
		}

		if(min_enemy != null)
		{
			LookAt(min_enemy.Position);
			crosshair.GlobalPosition = min_enemy.Position;
		} 
		
	}
}

