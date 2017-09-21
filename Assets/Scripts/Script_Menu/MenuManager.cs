using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public string sceneToLoad;
    private bool isPause = false;


    public void QuitMenu ()
   	{
        Application.Quit();
        Debug.Log("quit game");
    }

	public void PlayMenu ()
   	{
        SceneManager.LoadScene (sceneToLoad);
   	}

    void PauseMenu ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPause = !isPause;

       
    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}