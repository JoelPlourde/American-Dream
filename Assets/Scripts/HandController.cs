using UnityEngine;
using Valve.VR;

public enum Side
{
	Left, Right
}

public class HandController : MonoBehaviour
{
	public Side side;
	
	public float Speed = 10;
	
	// Reference to the core components.
	public Wheel LeftWheel;
	public Wheel RightWheel;
	public Wheelchair Wheelchair;
	
	// Temporary variable for the angle calculation
	private Vector3 _currentPosition;
	private Vector3 _lastPosition;
	private Vector3 _u;
	private Vector3 _v;

	[SteamVR_DefaultAction("GrabGrip")]
	private SteamVR_Action_Boolean _grabGripAction;

	private void Start()
	{
		_currentPosition = Vector3.zero;
		_lastPosition = Vector3.zero;
	}	
	  
	private void Update () 
	{
		if(side == Side.Left)
		{
			if (_grabGripAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
			{
				if (LeftWheel.Enable)
				{
					_currentPosition = transform.position;

					if (_lastPosition != Vector3.zero)
					{
						_u = _currentPosition - LeftWheel.transform.position;
						_v = _lastPosition - LeftWheel.transform.position;

						Wheelchair.LeftWheelDirection = (_lastPosition.z > _currentPosition.z) ? Direction.Backward : Direction.Forward;
						Wheelchair.LeftArc = Mathf.Acos((Vector3.Dot(_u, _v)) / (_u.magnitude * _v.magnitude));
					}

					_lastPosition = _currentPosition;
				}
			}
		}
		else if(side == Side.Right)
		{
			if (_grabGripAction.GetStateDown(SteamVR_Input_Sources.RightHand))
			{
				if (RightWheel.Enable)
				{
					_currentPosition = transform.position;

					if (_lastPosition != Vector3.zero)
					{
						_u = _currentPosition - RightWheel.transform.position;
						_v = _lastPosition - RightWheel.transform.position;

						Wheelchair.RightWheelDirection = (_lastPosition.z > _currentPosition.z) ? Direction.Backward : Direction.Forward;
						Wheelchair.RightArc = Mathf.Acos((Vector3.Dot(_u, _v)) / (_u.magnitude * _v.magnitude));
					}

					_lastPosition = _currentPosition;
				}
			}
		}
    }
}
