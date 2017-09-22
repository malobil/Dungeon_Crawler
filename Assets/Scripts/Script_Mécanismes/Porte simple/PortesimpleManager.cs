using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortesimpleManager : MonoBehaviour 
{
	private bool isOpen = false; 
	public Animator myDoorAnimator;

	public void ToggleOuverturePorte () 
	{
		if (!isOpen)
		{
			myDoorAnimator.SetTrigger("OpenDoor");
		}
		else if (isOpen)
		{
			myDoorAnimator.SetTrigger("CloseDoor");	
		}
	}

	public void SetOpen (){
		isOpen = true;
		myDoorAnimator.ResetTrigger("OpenDoor");
	}

	public void SetClosed (){
		
		isOpen = false;
		myDoorAnimator.ResetTrigger("CloseDoor");
		
	}
}