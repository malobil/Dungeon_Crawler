using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteManager : MonoBehaviour 
{
	public Animator myLittleDoorPoney;

	public void OuverturePorte () 
		{
			myLittleDoorPoney.SetTrigger("OpenDoor");
		}
	
}
