using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portesimple : MonoBehaviour 
{
public int range;

void FixedUpdate () 
	{
		RaycastHit hit ;

		if (Input.GetMouseButtonDown(0))
        {
          	Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
           	if (Physics.Raycast(raycast,out hit,range))
			{
				if (hit.collider.tag == "Portesimple"){
		   			hit.collider.GetComponent<PortesimpleManager>().ToggleOuverturePorte();
		   		}
			}
			
        }
    }
}

