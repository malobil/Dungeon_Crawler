using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteManager : MonoBehaviour 
{
	private bool isGopen = false; 
	public Animator myLittleDoorPoney;

	public void ToggleOuverturePorte () 
	{
		if (!isGopen)
		{
			myLittleDoorPoney.SetTrigger("OpenDoor");
		}
		else if (isGopen)
		{
			myLittleDoorPoney.SetTrigger("CloseDoor");	
		}
	}

	public void SetOpen (){
		isGopen = true;
		myLittleDoorPoney.ResetTrigger("OpenDoor");
	}

	public void SetClosed (){
		isGopen = false;
		myLittleDoorPoney.ResetTrigger("CloseDoor");
	}
}