using Godot;
using System;

public partial class Level1 : StaticBody2D
{
	private AnimatedSprite2D backgroundEffects;
	private double _effectTimer = 0;
	private double _wholeNumber = 1;
	PackedScene backgroundEffect;
	// Called when the node enters the scene tree for the first time.
	
	public override void _Ready()
	{
		backgroundEffect = (PackedScene)ResourceLoader.Load("res://Level1/level_1_background_effects.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
            _effectTimer += delta * 3; 
			if ((int)(_effectTimer) == _wholeNumber){
				_wholeNumber++;
				AnimatedSprite2D instance = (AnimatedSprite2D)backgroundEffect.Instantiate();
				AddChild(instance);
			}

			
	}
}
