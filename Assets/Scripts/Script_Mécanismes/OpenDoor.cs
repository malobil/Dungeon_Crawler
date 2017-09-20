using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour 
{

void FixedUpdate () 
	{
		RaycastHit hit ;

		if (Input.GetMouseButtonDown(0))
        {
          	Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
           	if (Physics.Raycast(raycast,out hit,4) && (hit.collider.tag == "Test Boutton"))
			{
		   		GetComponent<Animator>().SetTrigger("OpenDoor");
			}
        }
    }
}
