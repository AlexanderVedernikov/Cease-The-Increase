using Godot;
using System;

public partial class Level1BackgroundEffects : AnimatedSprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Random rnd = new Random();
		Play("A4Animation");
		Position = new Godot.Vector2(rnd.Next(150, 3300), rnd.Next(100, 900));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!IsPlaying()){
			Hide();
			QueueFree();
		}		
	}
}
