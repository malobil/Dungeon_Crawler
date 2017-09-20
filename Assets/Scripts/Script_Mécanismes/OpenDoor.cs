using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour 
{
public int Raylist;

void FixedUpdate () 
	{
		RaycastHit hit ;

		if (Input.GetMouseButtonDown(0))
        {
          	Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
           	if (Physics.Raycast(raycast,out hit,Raylist) && (hit.collider.tag == "Test boutton"))
			{
		   		GetComponent<Animator>().SetTrigger("OpenDoor");
			}
        }
    }
}
