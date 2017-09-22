using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCoffreManager : MonoBehaviour {

	public Transform spawnPosition;
	private ScriptableItem itemToLoot;
	public ItemInCoffreManager associateListScriptable;

	// Use this for initialization
	void Start () {
		int temp = Random.Range(0,associateListScriptable.listOfItem.Length);
		itemToLoot = associateListScriptable.listOfItem[temp];
		Instantiate (itemToLoot.itemPrefab, spawnPosition.position, spawnPosition.rotation, spawnPosition);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
