using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour 
{

void FixedUpdate () 
	{
		RaycastHit hit ;

		if (Physics.Raycast(transform.position,transform.forward, out hit,4))
		{
		   gameObject.GetComponent<Animator>().SetTrigger("OpenDoor");
		}
		//if (other.gameObject.tag == "...")
	}
}

