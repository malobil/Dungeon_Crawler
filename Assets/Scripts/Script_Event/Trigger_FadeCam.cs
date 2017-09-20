using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Trigger_FadeCam : MonoBehaviour {

	public float fadeSpeed ;
	public Image classicScreen ;
	private bool screenChange;
	private Color c ;
	private bool fade ; 

	// Use this for initialization
	void Start () {
		c.a = 1f ; 
		screenChange = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (screenChange && c.a >= 0)
		{
			c.a -= Time.deltaTime * fadeSpeed ;
			classicScreen.color = c;
		}
		else if (!screenChange)
		{
			c.a += Time.deltaTime * fadeSpeed ;
			classicScreen.color = c;
		}
		
	}

	void Fade () {
		screenChange = false ;
	}
}
