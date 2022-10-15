using Godot;
using System;

public class MainMenu : Control
{
	public Button Play;
	public CheckButton Mode1;
	public CheckButton Mode2;
	
	public override void _Ready()
	{
		Play = GetNode<Button>("PlayBttn");
		Mode1 = GetNode<CheckButton>("Mode1Check");
		Mode2 = GetNode<CheckButton>("Mode2Check");
		
		Mode1.Pressed = true;
		Mode2.Pressed = false;
		
	}
	
	private void _on_Mode1Check_pressed()
	{
		Mode2.Pressed = false;
		Global.gameMode = "towerdefense";
	}
	
	private void _on_Mode2Check_pressed()
	{
		Mode1.Pressed = false;
		Global.gameMode = "endless";
	}
	
	private void _on_PlayBttn_mouse_entered()
	{
		Play.Text = "Play?";
	}
	
	private void _on_PlayBttn_mouse_exited()
	{
		Play.Text = "Play";
	}
	
	private void _on_PlayBttn_pressed()
	{
		GetTree().ChangeScene("res://Scenes/GameScene.tscn");
	}

}



















