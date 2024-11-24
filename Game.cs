using Godot;
using System;
using System.Collections.Generic;

public partial class Game : Node2D, Unit
{

	private Vector2 targetPosition = Vector2.Zero;
	private Vector2 currentVelocity = Vector2.Zero;
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
		player.Velocity = currentVelocity;
		player.MoveAndSlide();
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		base._UnhandledInput(@event);
		if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.IsReleased())
		{
			var velocity = Vector2.Zero;
			var mousePosition = GetGlobalMousePosition();
			targetPosition = mousePosition;
			GD.Print($"Set target position: {targetPosition}");
			float distance = (targetPosition - player.GlobalPosition).Length();
			Vector2 direction = (targetPosition - player.GlobalPosition).Normalized();
			currentVelocity = direction * Player.Speed;


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
