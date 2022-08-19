using Godot;
using System;

public class Trail : Line2D
{
	public int length = 30;
	public Vector2 point;
	public KinematicBody2D Player;
	
	public override void _Ready()
	{
		Player = GetNode<KinematicBody2D>("/root/Node2D/Player");
	}
	
	public override void _Process(float delta)
	{
		GlobalPosition = new Vector2(0, 0);
		GlobalRotation = 0;
		
		point = Player.GlobalPosition;
		
		AddPoint(point);
		
		while (GetPointCount() > length)
		{
			RemovePoint(0);
		}
	}
}
