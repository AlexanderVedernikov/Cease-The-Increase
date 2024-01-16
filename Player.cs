using Godot;
using System;

public partial class Player : Node2D
{
	private int _speed = 400;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;
        if (Input.IsActionPressed("ui_up"))
        {
            velocity.Y += -1 * _speed;
        }
		if (Input.IsActionPressed("ui_down"))
        {
            velocity.Y += 1 * _speed;
        }
		if (Input.IsActionPressed("ui_left"))
        {
            velocity.X += -1 * _speed;
        }
		if (Input.IsActionPressed("ui_right"))
        {
            velocity.X += 1 * _speed;
        }

        Position += velocity * (float)delta;
	}
}
