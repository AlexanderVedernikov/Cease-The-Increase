using Godot;
using System;
using System.Numerics;

// Class defining player functionality
public partial class Player : CharacterBody2D
{
	private float _runSpeed = 350;
    private float _jumpStrength = -700;
    private float _longJump = -30;
    private float _gravity = 3500;
    private int _direction = 1;

    //The number of seconds the player has been idle (not moving)
    private double _idleTimer = 0;
    private AnimatedSprite2D _idleAnimation;
    private Sprite2D characterSprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        _idleAnimation = GetNode<AnimatedSprite2D>("IdleAnimation");
        characterSprite = GetNode<Sprite2D>("CharacterSprite");
        characterSprite.Show();
        _idleAnimation.Show();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame (in seconds).
	public override void _Process(double delta)
	{
        _idleTimer += delta; // Controls idle animation
		if (_idleTimer >= 2 && !_idleAnimation.IsPlaying()){
            characterSprite.Hide();
            _idleAnimation.Show();
            _idleAnimation.Play("IdleAnimation");
        } else if (_idleTimer < 2){
            _idleAnimation.Stop();
            _idleAnimation.Hide();
            characterSprite.Show();
        }
	}

    // Updates the player's velocity based on key presses
    public void GetInput()
    {
        var newVel = Velocity;
        newVel.X = 0;

        var right = Input.IsActionPressed("ui_right");
        var left = Input.IsActionPressed("ui_left");
        var jump = Input.IsActionPressed("ui_up");

        if (right || left || jump){
            _idleTimer = 0;
        }

        if (IsOnFloor() && jump){
            newVel.Y += _jumpStrength;
        } else if (jump && newVel.Y < 0){
            newVel.Y += _longJump;
        }
        
        if (right){
            newVel.X += _runSpeed;
        }
        if (left){
            newVel.X -= _runSpeed;
        }

        Velocity = newVel;
    }

    public override void _PhysicsProcess(double delta)
    {
        // Apply gravity
        var newVel = Velocity;
        newVel.Y += _gravity * (float)delta;
        Velocity = newVel;

        // If the velocity and direction aren't the same, that means that the character has started moving in the opposite direction
        if ((Mathf.Sign(newVel.X) != Mathf.Sign(_direction)) && (Mathf.Sign(newVel.X) != 0)){ 
            ApplyScale(new Godot.Vector2(-1, 1));
            _direction = _direction * -1;
        }

        GetInput();

        // Magic method to update player's pos and resolve collision
        MoveAndSlide();
    }
}
