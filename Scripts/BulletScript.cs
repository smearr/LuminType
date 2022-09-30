using Godot;
using System;

public class BulletScript : KinematicBody2D
{
	public Vector2 Velocity;
	public LineEdit Typer;
	
	public override void _Ready()
	{
		Typer = GetNode<LineEdit>("/root/Node2D/Typer");
	}
	
	public override void _PhysicsProcess(float delta)
	{
		Velocity = (Global.pos - Position).Normalized() * 4000;
		Velocity = MoveAndSlide(Velocity);
		LookAt(Global.pos);
		
		if(Global.KillConfirm == true)
		{
			QueueFree();
			Global.KillConfirm = false;
			Global.isShooting = false;
		}
		
	}

}






