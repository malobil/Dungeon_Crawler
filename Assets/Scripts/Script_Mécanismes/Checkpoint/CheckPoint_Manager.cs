using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint_Manager : MonoBehaviour 
{


	 void OnTriggerEnter(Collider col)
   	{
   		if (col.CompareTag("Player"))
   		{
    	 	col.GetComponent<Wilfried_Moves>().SetRespawn();

    	 	Destroy(gameObject);

        }

	}

}