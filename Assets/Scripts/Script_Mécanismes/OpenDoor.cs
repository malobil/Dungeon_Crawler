using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour 
{
public int range = 50;

void Update () 
	{

	}


void FixedUpdate () 
	{
		if(Input.GetMouseButtonDown(1))
		{
			RaycastHit hit ;
	        Debug.DrawRay(transform.position,Vector3.forward * range,Color.green);
	        if (Physics.Raycast(transform.position,transform.forward,out hit, range))
	        {
	        	if (hit.collider.tag == "Test boutton")
				{
			   		hit.collider.GetComponent<PorteManager>().ToggleOuverturePorte();
				}
			}
		}
    }
}


