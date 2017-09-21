using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreManager : MonoBehaviour 
{
private bool isOpen = false; 

public void ToggleOuvertureCoffre () 
	{
		if (!isOpen)
		{
			GetComponent<Animator>().SetTrigger("OpenCoffre");
			isOpen = true;
		}
		else 
		{
			GetComponent<Animator>().SetTrigger("CloseDoor");
			isOpen = false;		
		}
	}
}