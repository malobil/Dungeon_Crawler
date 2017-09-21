using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreManager : MonoBehaviour 
{
	public Animator myCoffreAnimator;
	private bool isOpen = false; 

	public void ToggleOuvertureCoffre () 
	{
		if (!isOpen)
		{
			myCoffreAnimator.SetTrigger("OpenCoffre");
		}
		else if (isOpen)
		{
			myCoffreAnimator.SetTrigger("CloseDoor");	
		}
	}

	public void SetOpen (){
		isOpen = true;
		myCoffreAnimator.ResetTrigger("OpenCoffre");
	}

	public void SetClosed (){
		isOpen = false;
		myCoffreAnimator.ResetTrigger("CloseDoor");
	}
}