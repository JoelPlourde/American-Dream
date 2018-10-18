using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour 
{
	public bool Enable;
	
	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("HandController"))
			Enable = true;
	}
	
	public void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("HandController"))
			Enable = false;
	}
}
