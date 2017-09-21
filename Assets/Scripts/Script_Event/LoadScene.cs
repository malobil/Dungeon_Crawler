using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string sceneToLoad;

	 void OnTriggerEnter(Collider other)
   	{
   		if (other.CompareTag("Player"))
   		{
        	SceneManager.LoadScene (sceneToLoad);
        }
   	}
}
