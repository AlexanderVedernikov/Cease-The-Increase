using Godot;
using System;
using System.Numerics;

// Class defining player functionality
public partial class Player : CharacterBody2D
{
	private float _runSpeed = 350;
    private float _jumpSpeed = -1000;
    private float _gravity = 2500;
    private int _direction = 1;

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
        var newVel = Velocity;
        newVel.X = 0;

        var right = Input.IsActionPressed("ui_right");
        var left = Input.IsActionPressed("ui_left");
        var jump = Input.IsActionPressed("ui_up");

        if (IsOnFloor() && jump)
            newVel.Y = _jumpSpeed;
        if (right)
            newVel.X += _runSpeed;
        if (left)
            newVel.X -= _runSpeed;

        Velocity = newVel;
    }

    public override void _PhysicsProcess(double delta)
    {
        var newVel = Velocity;
        newVel.Y += _gravity * (float)delta;
        Velocity = newVel;
        if ((Mathf.Sign(newVel.X) != Mathf.Sign(_direction)) & (Mathf.Sign(newVel.X) != 0)){ //If the velocity and direction aren't the same, that means that the character has started moving in the opposite direction
            ApplyScale(new Godot.Vector2(-1, 1));
            _direction = _direction * -1;
        }
        GetInput();
        MoveAndSlide();
    }
}
