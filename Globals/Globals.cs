using Godot;
using System;

public partial class Globals : Node
{
	// Called when the node enters the scene tree for the first time.
	public static Globals Instance { get; private set; }
	public double playerHealth { get; set; }
	public override void _Ready()
	{
		Instance = this;
		playerHealth = 100;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
