using Godot;
using System;

public class Menu : Panel
{
	public Button PlayAgain;
	public Button Exit;
	public Label WPM;
	
	public override void _Ready()
	{
		PlayAgain = GetNode<Button>("PlayAgainBttn");
		Exit = GetNode<Button>("ExitBttn");
		WPM = GetNode<Label>("GameOverWPM");
	}
	
	private void _on_PlayAgainBttn_mouse_entered()
	{
		PlayAgain.Text = "Play Again?";
	}
	
	private void _on_PlayAgainBttn_mouse_exited()
	{
		PlayAgain.Text = "Play Again";
	}

	private void _on_ExitBttn_mouse_entered()
	{
		Exit.Text = "Exit?";
	}
	
	private void _on_ExitBttn_mouse_exited()
	{
		Exit.Text = "Exit";
	}

	private void _on_PlayAgainBttn_pressed()
	{
		GetTree().ReloadCurrentScene();
		GetTree().Paused = false;
		Global.WordsTyped = 0;
	}
	
	private void _on_ExitBttn_pressed()
	{
		GetTree().ChangeScene("res://Scenes/MainMenu.tscn");
		Global.WordsTyped = 0;
		GetTree().Paused = false;
	}
}















