using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.EventSystems ;

public class InventoryGemSystem : MonoBehaviour {

	public GameObject window ;
	public Image icon ;
	public Text nameText ;
	public Text statText ;

	private ScriptableItem associateScriptable ;
	private int slotUse ;
	private bool slotIsFree = true ;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void AddGemToSlot(ScriptableItem scriptable, int slotNumber)
    {  
        associateScriptable = scriptable ;
        icon.sprite = associateScriptable.inventorySprite ;
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
        
        slotUse = slotNumber ;
     	slotIsFree = false ;
    }

    public void RetireGem(BaseEventData data)
    {
    	PointerEventData ped = ( PointerEventData )data;
        if(ped.button == PointerEventData.InputButton.Right && !InventoryManagerK.Instance().CheckIfFull())
        {
            InventoryManagerK.Instance().RetireGem(slotUse,associateScriptable) ;
            associateScriptable = null ;
            slotUse = 0 ;
            icon.sprite = null ;
            slotIsFree = true ;
        }
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
}
