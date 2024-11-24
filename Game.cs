using Godot;
using System;
using System.Collections.Generic;

public partial class Game : Node2D, Unit
{


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Player>("Player");
		enemy = GetNode<Enemy>("Enemy");
		camera = GetNode<Camera2D>("Camera2D");

		units = new List<Unit>() { player, enemy };
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = player.Velocity;
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity = direction * Player.Speed;
		}
		else
		{
			velocity = new Vector2(
				Mathf.MoveToward(player.Velocity.X, 0, Player.Speed),
				Mathf.MoveToward(player.Velocity.Y, 0, Player.Speed)
			);
		}

		player.Velocity = velocity;
		player.MoveAndSlide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private Player player;
	private Enemy enemy;
	private Camera2D camera;
	private List<Unit> units = new();

}
