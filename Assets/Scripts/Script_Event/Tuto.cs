using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tuto : MonoBehaviour {

    public GameObject tuto;
    private bool isTutoDone = true; 

	 void OnTriggerEnter(Collider other)
   	{
   		if (isTutoDone== true  && other.CompareTag("Player"))
   		{
        	tuto.SetActive (true);
        }
   	}
   	void OnTriggerExit(Collider other)
   	{
   		if (other.CompareTag("Player"))
   		{
        	tuto.SetActive (false);
        	isTutoDone = false; 
        }
    }
}

