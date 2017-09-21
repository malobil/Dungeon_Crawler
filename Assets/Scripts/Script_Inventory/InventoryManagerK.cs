using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class InventoryManagerK : MonoBehaviour {

	public GameObject[] slot ;
	public ScriptableItem[] objectInSlot ;

	public ScriptableItem[] gemEquip ;
	public GameObject[] gemSlot ;

	private bool alreadyPut = false ;
	private bool alreadyPutGem = false ;

	private int slotOcupied = 0 ;
	private bool gemInventoryIsFull = false;

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

	public void AddGem(ScriptableItem associateScriptable, int slotUse)
	{
		alreadyPutGem = false ;

		//Debug.Log("Input") ;

		for(int i = 0 ; i < gemSlot.Length ; i++)
		{
			//Debug.Log("Boucle") ;
			if(gemEquip[i] == null && !alreadyPutGem)
			{
				//Debug.Log("Condition") ;
				gemSlot[i].GetComponent<InventoryGemSystem>().AddGemToSlot(associateScriptable,slotUse) ;
				gemEquip[i] = associateScriptable ;
				alreadyPutGem = true ;
				objectInSlot[slotUse] = null ;
			}
		}
	}

	public bool CheckIfGemFull()
	{
		slotOcupied = 0 ;

		for(int i = 0 ; i < gemEquip.Length ; i++)
		{
			if(gemEquip[i] != null)
			{
				slotOcupied++ ;
			}
		}

		if(slotOcupied >= gemEquip.Length)
		{
			gemInventoryIsFull = true ;
		}
		else
		{
			gemInventoryIsFull = false ;
		}

		return gemInventoryIsFull ;
	}
}
