using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;

public class EnemyScene : KinematicBody2D
{
	public int runSpeed = 75;
	public Vector2 velocity;
	
	public Label Text;
	public LineEdit Typer;
	public KinematicBody2D Player;
	public Area2D crystal;
	
	Random word_from_list = new Random();
	
	public override void _Ready()
	{
		Player = GetNode<KinematicBody2D>("/root/Node2D/Player");
		Text = GetNode<Label>("Text");
		
		Typer = GetNode<LineEdit>("/root/Node2D/Typer");
		crystal = GetNode<Area2D>("/root/Node2D/Crystal");
		
		
		Text.Text = Global.easy_words[word_from_list.Next(0, Global.easy_words.Length)];
	}


	public override void _Process(float delta)
	{
		velocity = (crystal.Position - Position).Normalized() * runSpeed;
		velocity = MoveAndSlide(velocity);
		
		if (Typer.Text == Text.Text)
		{
			Enemy_Kill();
		}
	
	}
	
	public void Enemy_Kill()
	{
		Typer.Text = "";
		QueueFree();
	}
	
	
}
