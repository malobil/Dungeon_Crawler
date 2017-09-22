using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour 
{
	public Animator myPorteAnimator;
	private bool isOpen = false; 

	public void ToggleOuverturePorte () 
	{
		if (!isOpen)
		{
			myPorteAnimator.SetTrigger("OpenDoor");
		}
		else if (isOpen)
		{
			myPorteAnimator.SetTrigger("CloseDoor");	
		}
	}

	public void SetOpen (){
		isOpen = true;
		myPorteAnimator.ResetTrigger("OpenDoor");
	}

	public void SetClosed (){
		isOpen = false;
		myPorteAnimator.ResetTrigger("CloseDoor");
	}
}