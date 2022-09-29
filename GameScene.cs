using Godot;
using System;
using System.Linq;

public class GameScene : Node2D
{
	public Timer SpawnTimer;
	public Timer GameOverTimer;
	
	public LineEdit Typer;
	public AnimatedSprite PlayerSprite;
	public KinematicBody2D Player;
	public KinematicBody2D Enemy;
	public WorldEnvironment world;
	public Area2D crystal;
	public CanvasLayer gameoverUI;
	public Label GameOverWPM;
	
	public Label Text;
	public Label WPM;
	Random pos = new Random();
	
	public PackedScene Enemy1 = ResourceLoader.Load("res://Scenes/EnemyScene.tscn") as PackedScene;
	public PackedScene DeathEffect = ResourceLoader.Load("res://Scenes/ParticleScene.tscn") as PackedScene;
	public PackedScene GameOverEffect = ResourceLoader.Load("res://Scenes/GameOverParticle.tscn") as PackedScene;
	
	public float elapsed_time = 0;


	public override void _Ready()
	{
		SpawnTimer = GetNode<Timer>("SpawnTimer");
		Typer = GetNode<LineEdit>("Typer");
		WPM = GetNode<Label>("WPM");
		Player = GetNode<KinematicBody2D>("Player");
		world = GetNode<WorldEnvironment>("WorldEnvironment");
		gameoverUI = GetNode<CanvasLayer>("CanvasLayer");
		GameOverWPM = GetNode<Label>("CanvasLayer/Panel/GameOverWPM");
		GameOverTimer = GetNode<Timer>("GameOverPopupTimer");
		
	}
	
	public override void _Process(float delta)
	{

		elapsed_time += delta;
		WPM.Text = ((Global.WordsTyped / (elapsed_time / 60)) + " WPM");
		
		if(Global.is_dead == true)
		{	
			CPUParticles2D Particle1 = (CPUParticles2D)DeathEffect.Instance();
			AddChild(Particle1);
			Particle1.Position = Global.pos;
			Particle1.Emitting = true;
			Global.is_dead = false;
		}
	}
	
	private void _on_SpawnTimer_timeout()
	{
		KinematicBody2D Enemies1 = (KinematicBody2D)Enemy1.Instance();
		KinematicBody2D Enemies2 = (KinematicBody2D)Enemy1.Instance();
		
	
		AddChild(Enemies1);
		Enemies1.Position = new Vector2(0, pos.Next(0, 968));
		
		AddChild(Enemies2);
		Enemies2.Position = new Vector2(1270, pos.Next(0, 968));
	}
	
	private void _on_crystal_body_entered(KinematicBody2D body)
	{
		if(body.IsInGroup("Enemy"))
		{
			Game_Over();
		}
	}
	
	public void Game_Over()
	{
		CPUParticles2D Particle2 = (CPUParticles2D)GameOverEffect.Instance();
		elapsed_time = elapsed_time;
		GameOverWPM.Text = (Global.WordsTyped / (elapsed_time / 60)) + " WPM";
		AddChild(Particle2);
		GameOverTimer.Start();
		Particle2.Position = new Vector2(638, 394);
		Particle2.Emitting = true;
		GetTree().Paused = true;
	}
	
	private void _on_GameOverPopupTimer_timeout()
	{
		gameoverUI.Visible = true;
	}
}
























