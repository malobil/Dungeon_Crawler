using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCoffreManager : MonoBehaviour {

	public Transform coffrePosition;
	private ScriptableItem itemToLoot;
	public ItemInCoffreManager associateListScriptable;

	// Use this for initialization
	void Start () {
		int temp = Random.Range(0,associateListScriptable.listOfItem.Length);
		itemToLoot = associateListScriptable.listOfItem[temp];
		Instantiate (itemToLoot.itemPrefab, coffrePosition.position + Vector3.up, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
