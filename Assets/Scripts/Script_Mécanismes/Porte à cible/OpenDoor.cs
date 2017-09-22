using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour 
{
public int range = 50;

void FixedUpdate () 
	{
		RaycastHit hit ;

		if (Input.GetMouseButtonDown(0))
		{
	        Debug.DrawRay(transform.position,Vector3.forward * range,Color.green);
	        if (Physics.Raycast(transform.position,transform.forward,out hit, range))
	        {
	        	if (hit.collider.tag == "Test boutton")
				{
			   		hit.collider.GetComponent<PorteManager>().OuverturePorte();
				}
			}
		}
    }
}


