using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookObjController : MonoBehaviour 
{
    public Transform Camera;
    public float offset;

	void LateUpdate ()
    {
        transform.position = Camera.transform.position + (Camera.forward * offset);
	}
}
