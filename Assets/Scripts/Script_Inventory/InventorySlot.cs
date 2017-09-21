using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems ;
using UnityEngine.UI ;

public class InventorySlot : MonoBehaviour {

	public GameObject window ;
    public Image image ;
    public Text nameText, statText ;

	private bool slotIsFree = true ;
    private int slot ;

    private ScriptableItem associateScriptable ;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

	public void OnMouseEnter()
     {
     	if(!slotIsFree)
     	{
       	 	window.SetActive(true) ;
       	}
     }

     public void OnMouseExit()
     {
     	 window.SetActive(false) ;
     }

     public void AddObjectToSlot(ScriptableItem scriptable, int slotNumber)
     {  
        associateScriptable = scriptable ;
        image.sprite = associateScriptable.inventorySprite ;
        nameText.text = associateScriptable.itemName ;

        if(associateScriptable.healGain > 0)
        {
            statText.text = "Soin :" + associateScriptable.healGain ;
        }

        if(associateScriptable.atkBoost > 0)
        {
            statText.text = "Atk + " + associateScriptable.atkBoost.ToString("") + "\nVie + " + associateScriptable.hPBoost.ToString("") ;
        }

        if(associateScriptable.isGemRafined)
        {
            statText.text = associateScriptable.gemRafinedDescription ;
        }
        
        slot = slotNumber ;
     	slotIsFree = false ;
     }

     public void UseObject(BaseEventData data)
     {
        PointerEventData ped = ( PointerEventData )data;
        if(ped.button == PointerEventData.InputButton.Right)
        {
            if(associateScriptable.hPBoost > 0 &&  !InventoryManagerK.Instance().CheckIfGemFull() || associateScriptable.atkBoost > 0 &&  !InventoryManagerK.Instance().CheckIfGemFull())
            {
                Debug.Log("gem") ;
                InventoryManagerK.Instance().AddGem(associateScriptable,slot) ;
                slot = 0 ;
                image.sprite = null ;
                slotIsFree = true ;
                associateScriptable = null ;
            }
            else if(associateScriptable.healGain > 0)
            {
                Debug.Log("potion") ;
                InventoryManagerK.Instance().objectInSlot[slot] = null ;
                slot = 0 ;
                image.sprite = null ;
                slotIsFree = true ;
                associateScriptable = null ;
            }
        }
    
     }

     public void OnDrag(BaseEventData data)
     {
        PointerEventData ped = ( PointerEventData )data;
        transform.position = ped.position ;
     }
}
