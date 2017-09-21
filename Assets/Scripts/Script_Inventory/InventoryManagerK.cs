using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class InventoryManagerK : MonoBehaviour {

	public GameObject[] slot ;
	public ScriptableItem[] objectInSlot ;
	public LayerMask objectLayer ;

	private bool alreadyPut = false ;

	private static InventoryManagerK instance ;
	public static InventoryManagerK Instance () 
	{
		return instance;
	}

	void Awake ()
	{
		if (instance != null)
		{
			Destroy (gameObject);
		}
		else 
		{
			instance = this;
		}
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			DrawRay() ;
		}
	}

	void DrawRay()
	{
		RaycastHit hit ;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;

		if(Physics.Raycast(ray,out hit))
		{
			//Debug.Log("hey") ;

			if(hit.collider.transform.gameObject.layer == 10)
			{
				AddObjectToInventory(hit) ;
			}
		}
	}

	void AddObjectToInventory(RaycastHit hitObject)
	{
		alreadyPut = false ;

		//Debug.Log("Input") ;

		for(int i = 0 ; i < slot.Length ; i++)
		{
			//Debug.Log("Boucle") ;
			if(objectInSlot[i] == null && !alreadyPut)
			{
				//Debug.Log("Condition") ;

				ScriptableItem tempScriptable = hitObject.transform.gameObject.GetComponent<ItemApplication>().ReturnScriptable() ;

				slot[i].GetComponent<InventorySlot>().AddObjectToSlot(tempScriptable,i) ;
				objectInSlot[i] = tempScriptable ;
				alreadyPut = true ;
			}
		}
	}
}
