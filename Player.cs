using Godot;
using System;

public partial class Player : CharacterBody2D, Unit
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{


		// Add the gravity.
		// if (!IsOnFloor())
		// 	//velocity.Y += gravity * (float)delta;

		// Handle Jump.
		// if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		// 	//velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.

	}
}
