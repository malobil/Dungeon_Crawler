using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death_Manager : MonoBehaviour {

   
void start ()
{

}

	 void OnTriggerEnter(Collider col)
   	{
   		if (col.CompareTag("Player")) //&& damages_to_wilfried <= 0
   		{
        		col.GetComponent<Wilfried_Moves>().Respawn();
        }

	}
}
   	