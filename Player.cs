using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private float _runSpeed = 350;
    private float _jumpSpeed = -1000;
    private float _gravity = 2500;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

    public void GetInput()
    {
        var velocity = Velocity;
        velocity.X = 0;

        var right = Input.IsActionPressed("ui_right");
        var left = Input.IsActionPressed("ui_left");
        var jump = Input.IsActionPressed("ui_up");

        if (IsOnFloor() && jump)
            velocity.Y = _jumpSpeed;
        if (right)
            velocity.X += _runSpeed;
        if (left)
            velocity.X -= _runSpeed;

        Velocity = velocity;
    }

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;
        velocity.Y += _gravity * (float)delta;
        Velocity = velocity;
        GetInput();
        MoveAndSlide();
    }
}
