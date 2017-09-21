using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteManager : MonoBehaviour 
{
public void ToggleOuverturePorte () 
		{
			GetComponent<Animator>().SetTrigger("OpenDoor");
		}
}
