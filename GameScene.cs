using Godot;
using System;

public class GameScene : Node2D
{
	public KinematicBody2D Enemy;
	public Timer SpawnTimer;
	public LineEdit Typer;
	public CollisionShape2D crystalCollision;
	
	public PackedScene Enemy1 = ResourceLoader.Load("res://Scenes/EnemyScene.tscn") as PackedScene;



	public override void _Ready()
	{
		SpawnTimer = GetNode<Timer>("SpawnTimer");
		Typer = GetNode<LineEdit>("Typer");
		crystalCollision = GetNode<CollisionShape2D>("Crystal/CollisionShape2D");
		
	}
	
	private void _on_SpawnTimer_timeout()
	{
		KinematicBody2D Enemies1 = (KinematicBody2D)Enemy1.Instance();
		KinematicBody2D Enemies2 = (KinematicBody2D)Enemy1.Instance();
		
		AddChild(Enemies1);
		Enemies1.Position = new Vector2(0, 250);
		
		AddChild(Enemies2);
		Enemies2.Position = new Vector2(1333, 250);
	}
	
	private void _on_Crystal_body_entered(KinematicBody2D body)
	{
		GameOver();
	}
	
	public void GameOver()
	{
		GetTree().Paused = true;
	}
	
	
}






