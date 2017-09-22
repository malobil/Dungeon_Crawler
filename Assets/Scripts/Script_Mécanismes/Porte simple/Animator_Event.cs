using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Event : MonoBehaviour {
	public PortesimpleManager myDoorManager;
	public PortesimpleManager myDoorManager2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SendOpenMessage()
	{

		myDoorManager.SetOpen();
		myDoorManager2.SetOpen();
	}
	public void SendCloseMessage()
	{
		myDoorManager.SetClosed();
		myDoorManager2.SetClosed();
	}
	public void OpenSoundPlay(){
		GetComponent<AudioSource>().Play();
	}
	public void CloseSoundPlay(){
		GetComponent<AudioSource>().Play();		
	}
}