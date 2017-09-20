using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void QuitMenu ()
   	{
        Application.Quit();
        Debug.Log("quit game");
    }

	public void PlayMenu (string Menu_Scene_Jeu)
   	{
        SceneManager.LoadScene (Menu_Scene_Jeu);
   	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}