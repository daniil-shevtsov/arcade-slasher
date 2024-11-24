using Godot;
using System;
using System.Collections.Generic;

public partial class Game : Node2D, Unit
{

	private Vector2 targetPosition = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Player>("Player");
		targetPosition = player.GlobalPosition;
		enemy = GetNode<Enemy>("Enemy");
		camera = GetNode<Camera2D>("Camera2D");

		units = new List<Unit>() { player, enemy };
	}

	public override void _PhysicsProcess(double delta)
	{
		if (targetPosition != player.GlobalPosition)
		{
			Vector2 velocity = player.Velocity;
			Vector2 direction = (targetPosition - player.GlobalPosition).Normalized();
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
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		base._UnhandledInput(@event);
		if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.IsReleased())
		{
			var velocity = Vector2.Zero;
			var mousePosition = GetGlobalMousePosition();
			targetPosition = mousePosition;
			// velocity = mousePosition - player.GlobalPosition;
			// velocity = new Vector2(
			// 		Mathf.MoveToward(player.Velocity.X, velocity.X, Player.Speed),
			// 		Mathf.MoveToward(player.Velocity.Y, velocity.Y, Player.Speed)
			// );
			// targetVelocity = velocity;
			//player.Velocity = velocity;
			//player.MoveAndSlide();
		}
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
