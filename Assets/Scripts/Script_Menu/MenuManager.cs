﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public string sceneToLoad;

    public void QuitMenu ()
   	{
        Application.Quit();
        Debug.Log("quit game");
    }

	public void PlayMenu ()
   	{
        SceneManager.LoadScene (sceneToLoad);
   	}

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}