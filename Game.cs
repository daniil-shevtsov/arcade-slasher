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

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private Player player;
	private Enemy enemy;
	private Camera2D camera;
	private List<Unit> units = new();

}
