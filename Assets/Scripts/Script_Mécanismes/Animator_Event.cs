using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Event : MonoBehaviour {
	public PortesimpleManager myDoorManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SendOpenMessage()
	{
		myDoorManager.SetOpen();
	}
	public void SendCloseMessage()
	{
		myDoorManager.SetClosed();
	}
}