using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMana : MonoBehaviour {

	public void OpenSoundPlay ()
	{
		GetComponent<AudioSource>().Play();
	}
}
