using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
	None, Forward, Backward, Left, Right
}

public class Wheelchair : MonoBehaviour
{
	public float MovingSpeed = 0.5f;
	public float RotationSpeed = 1f;
	
	public float LeftArc;
	public float RightArc;
	
	public Direction LeftWheelDirection;
	public Direction RightWheelDirection;
	
	private Direction _wheelchairDirection;
	
	private float _translation;
	private float _rotation;
	
	private void Awake()
	{
		LeftArc = 0;
		RightArc = 0;
	}
	
	void LateUpdate()
	{
		// Determine the Wheelchair direction depending on the wheel direction.
		if(LeftWheelDirection == Direction.Forward && RightWheelDirection == Direction.Forward)
		{
			_wheelchairDirection = Direction.Forward;
			_translation = LeftArc + RightArc;
			_rotation = 0;
		}
		else if(LeftWheelDirection == Direction.Backward && RightWheelDirection == Direction.Backward)
		{
			_wheelchairDirection = Direction.Backward;
			_translation = -(LeftArc + RightArc);
			_rotation = 0;
		}
		else if(LeftWheelDirection == Direction.Forward)
		{
			_wheelchairDirection = Direction.Right;
			_translation = (LeftArc - RightArc);
			_rotation = -(LeftArc + RightArc);
		}
		else if(RightWheelDirection == Direction.Forward)
		{
			_wheelchairDirection = Direction.Left;
			_translation = (-LeftArc + RightArc);
			_rotation = (LeftArc + RightArc);
		}
		else
		{
			_wheelchairDirection = Direction.None;
			_translation = 0;
			
		}
		
		if(float.IsNaN(_translation))
		{
			_translation = 0;
		}
		
		if(float.IsNaN(_rotation))
		{
			_rotation = 0;
		}
		
		transform.Translate(transform.forward * _translation * MovingSpeed);
		transform.Rotate(transform.up * _rotation * RotationSpeed, Space.World);
	}
}
