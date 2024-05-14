using Godot;
using System;

public partial class Level1 : StaticBody2D
{
	private AnimatedSprite2D backgroundEffects;
	// Called when the node enters the scene tree for the first time.
	
	public override void _Ready()
	{
		backgroundEffects = GetNode<AnimatedSprite2D>("Level1BackgroundEffects");
		backgroundEffects.Play("A4Animation");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
