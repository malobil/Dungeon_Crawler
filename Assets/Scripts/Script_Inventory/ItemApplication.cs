using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemApplication : MonoBehaviour {

	public ScriptableItem associateScriptable ;

	public ScriptableItem ReturnScriptable()
	{
		return associateScriptable ;
	}
}
