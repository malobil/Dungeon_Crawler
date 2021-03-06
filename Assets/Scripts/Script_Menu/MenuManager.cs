﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    public string Scene_LevelD;
    private bool isPause = false;
    public GameObject menuPause;

    public void QuitMenuAccueil ()
   	{
        Application.Quit();
        Debug.Log("quit game");
    }

	public void PlayMenuAccueil ()
   	{
        SceneManager.LoadScene (Scene_LevelD);
   	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Continuer();
        } 
	}

    public void Continuer ()
    {
        isPause = !isPause;
        menuPause.SetActive(isPause);
    }

    public void QuitterPause ()
    {
       SceneManager.LoadScene (Scene_LevelD);
    }
}