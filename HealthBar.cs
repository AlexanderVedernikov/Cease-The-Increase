using Godot;
using System;

public partial class HealthBar : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private TextureProgressBar HealthBarVar;
	public override void _Ready()
	{
		Globals.Instance.playerHealth = 90;
		HealthBarVar = GetNode<TextureProgressBar>("Healthbar");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		HealthBarVar.Value = Globals.Instance.playerHealth;
		Globals.Instance.playerHealth -= 3 * delta;
	}
}
