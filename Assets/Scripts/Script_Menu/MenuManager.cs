﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    public string sceneToLoad;
    private bool isPause = false;
    public GameObject menuPause;
    public GameObject menu;

    public void QuitMenuAccueil ()
   	{
        Application.Quit();
        Debug.Log("quit game");
    }

	public void PlayMenuAccueil ()
   	{
        SceneManager.LoadScene (sceneToLoad);
   	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            menuPause.SetActive(isPause);
        } 
	}

    public void continuer ()
    {
        menuPause.SetActive(false);
    }

    public void quitterPause ()
    {
        menuPause.SetActive(false);
        menu.SetActive(true);
    }
}