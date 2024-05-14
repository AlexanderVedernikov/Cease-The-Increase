using Godot;
using System;

public partial class CeaseTheIncreasePlatform : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	private AnimatedSprite2D platformAnimation;
	public override void _Ready()
	{
		platformAnimation = GetNode<AnimatedSprite2D>("PlatformAnimation");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!platformAnimation.IsPlaying()){
            platformAnimation.Play("PlatformAnimation");
        }
	}
}
