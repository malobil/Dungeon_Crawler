using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public List<GameObject> slot = new List<GameObject>() ;
	public List<GameObject> imageSlot = new List<GameObject>() ;
	public GameObject refImage ;
	private bool haveSlot = false ;
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit ;
		// ClickOnItem
		Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(raycast,out hit,4) && (hit.collider.tag == "Item"))
			{       
				haveSlot = false ; // You can add an item in a slot
				Debug.Log("haha") ;
				for(int i = 0; i < slot.Count; i++) // Continue until slot limit is reached
				{
					Debug.Log("urrryyyy");
					if(slot[i] == null && !haveSlot) // If there is no slot here 
					{
						Debug.Log("muda");
						GameObject itemInSlot = Instantiate(refImage,imageSlot[i].transform) ; // Create an image of the item selected
						slot[i] = itemInSlot;
						haveSlot = true ;
					}
				}
			}
		}
	}
}