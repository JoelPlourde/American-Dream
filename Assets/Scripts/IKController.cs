using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
	private Animator _anim;
	
	public Transform RightHandObj;
	public Transform LeftHandObj;
	
	public Transform LeftFootObj;
	public Transform RightFootObj;
	
	public Transform LookObj;

    public float weight;

	void Start ()
	{
		_anim = GetComponent<Animator>();
	}
	
	void OnAnimatorIK()
     {
         if (_anim)
         {
			 // Set the look target position, if one has been assigned
			 if (LookObj != null)
			 {
				_anim.SetLookAtWeight(weight, weight);
				_anim.SetLookAtPosition(LookObj.localPosition);
			 }

			 // Set the right hand target position and rotation, if one has been assigned
			 if (RightHandObj != null)
			 {
				_anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
				_anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
				_anim.SetIKPosition(AvatarIKGoal.RightHand, RightHandObj.position);
				_anim.SetIKRotation(AvatarIKGoal.RightHand, RightHandObj.rotation);
			 }

			 if (LeftHandObj != null)
			 {
				_anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
				_anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
				_anim.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandObj.position);
				_anim.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandObj.rotation);
			 }

			//is this necessary to even track the legs?
			//Won't they be static?			 
			 if (LeftFootObj != null)
			 {
				_anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
				_anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
				_anim.SetIKPosition(AvatarIKGoal.LeftFoot, LeftFootObj.position);
				_anim.SetIKRotation(AvatarIKGoal.LeftFoot, LeftFootObj.rotation);
			 }
			 
			 if (RightFootObj != null)
			 {
				_anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
				_anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
				_anim.SetIKPosition(AvatarIKGoal.RightFoot, RightFootObj.position);
				_anim.SetIKRotation(AvatarIKGoal.RightFoot, RightFootObj.rotation);
			 }
         }
     }
}
