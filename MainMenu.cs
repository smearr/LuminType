using Godot;
using System;

public class MainMenu : Control
{
	public Button Play;
	
	public override void _Ready()
	{
		Play = GetNode<Button>("PlayBttn");
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








