using Godot;
using System;
using System.Linq;
using System.Collections.Generic;


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
	public AudioStreamPlayer2D soundfx;
	public CollisionShape2D crystalcollider;
	
	public Label Text;
	public Label WPM;
	Random pos = new Random();
	
	public PackedScene Enemy1 = ResourceLoader.Load("res://Scenes/EnemyScene.tscn") as PackedScene;
	public PackedScene DeathEffect = ResourceLoader.Load("res://Scenes/ParticleScene.tscn") as PackedScene;
	public PackedScene GameOverEffect = ResourceLoader.Load("res://Scenes/GameOverParticle.tscn") as PackedScene;
	public PackedScene Bullet = ResourceLoader.Load("res://Scenes/BulletScene.tscn") as PackedScene;
	
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
		soundfx = GetNode<AudioStreamPlayer2D>("soundfx");
		crystalcollider = GetNode<CollisionShape2D>("crystal/CollisionShape2D");
		crystal = GetNode<Area2D>("crystal");
		
		if (Global.gameMode == "endless")
		{
			KinematicBody2D Enemies1 = (KinematicBody2D)Enemy1.Instance();
			KinematicBody2D Enemies2 = (KinematicBody2D)Enemy1.Instance();
			
			crystal.Position = new Vector2(10000,10000);
			Typer.RectPosition = new Vector2(518, 702);
		}
		
		
	}
	
	public override void _Process(float delta)
	{

		elapsed_time += delta;
		WPM.Text = ((Global.WordsTyped / (elapsed_time / 60)) + " WPM");
		

		
		if(Global.is_dead == true)
		{	
			CPUParticles2D Particle1 = (CPUParticles2D)DeathEffect.Instance();
			KinematicBody2D bullet = (KinematicBody2D)Bullet.Instance();
			AddChild(Particle1);
			Particle1.Position = Global.pos;
			Particle1.Emitting = true;
			Global.is_dead = false;
			
		}
		
		if(Global.isShooting == true)
		{
			KinematicBody2D bullet = (KinematicBody2D)Bullet.Instance();

			AddChild(bullet);
			bullet.Position = Player.Position;
			Global.isShooting = false;
		}
		
		else if (Global.gameMode == "endless")
		{
			KinematicBody2D Enemies1 = (KinematicBody2D)Enemy1.Instance();
			KinematicBody2D Enemies2 = (KinematicBody2D)Enemy1.Instance();
			KinematicBody2D Enemies3 = (KinematicBody2D)Enemy1.Instance();
			KinematicBody2D Enemies4 = (KinematicBody2D)Enemy1.Instance();
			
			
			GD.Print(GetTree().GetNodesInGroup("Enemies").Count);
			
			if (GetTree().GetNodesInGroup("Enemies").Count <= 1)
			{
				Enemies2.AddToGroup("Enemies");
				Enemies2.Position = new Vector2(400, 410);
				AddChild(Enemies2);
				
				Enemies1.Position = new Vector2(100, 410);
				AddChild(Enemies1);
				Enemies1.AddToGroup("Enemies");
				
				Enemies3.AddToGroup("Enemies");
				Enemies3.Position = new Vector2(700, 410);
				AddChild(Enemies3);
				
				Enemies4.AddToGroup("Enemies");
				Enemies4.Position = new Vector2(1000, 410);
				AddChild(Enemies4);
	
				
			}
		}
		
		if (Input.IsActionPressed("ui_cancel"))
		{
			Game_Over();
		}
	}
	
	private void _on_SpawnTimer_timeout()
	{
		KinematicBody2D Enemies1 = (KinematicBody2D)Enemy1.Instance();
		KinematicBody2D Enemies2 = (KinematicBody2D)Enemy1.Instance();
		
		if (Global.gameMode == "towerdefense")
		{
			AddChild(Enemies1);
			Enemies1.Position = new Vector2(0, pos.Next(0, 968));
			
			AddChild(Enemies2);
			Enemies2.Position = new Vector2(1270, pos.Next(0, 968));
		}
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
	
	private void _on_BulletTimer_timeout()
	{
		Global.KillConfirm = true;
		soundfx.Playing = true;
	}
}



























