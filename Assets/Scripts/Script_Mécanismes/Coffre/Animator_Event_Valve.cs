using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Event_Valve : MonoBehaviour {
	
	public CoffreManager myCoffreManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SendOpenMessage()
	{
		myCoffreManager.SetOpen();
	}
	public void SendCloseMessage()
	{
		myCoffreManager.SetClosed();
	}
}