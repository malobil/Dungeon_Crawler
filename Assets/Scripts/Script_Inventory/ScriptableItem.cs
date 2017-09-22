using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "item")]
public class ScriptableItem : ScriptableObject 
{
	public Sprite inventorySprite ;
	public string itemName, gemRafinedDescription ;
	public float atkBoost,hPBoost, healGain ;
	public bool isGemRafined ;
	public AudioClip lootSound;
	public GameObject itemPrefab;
}
