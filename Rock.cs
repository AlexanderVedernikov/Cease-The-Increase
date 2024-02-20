using Godot;
using System;

public partial class Rock : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	private RigidBody2D _Rock;
	public override void _Ready()
	{
		_Rock = GetNode<RigidBody2D>("Rock");
		//_Rock.LinearVelocity = Vector2.Left * 1000;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
