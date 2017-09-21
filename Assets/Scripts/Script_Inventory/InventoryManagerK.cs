using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class InventoryManagerK : MonoBehaviour {

	public GameObject[] slot ;
	public ScriptableItem[] objectInSlot ;

	public ScriptableItem[] gemEquip ;
	public GameObject[] gemSlot ;

    public GameObject item_Info_Window;
    public Text item_Name;

    public Text stats_Name;

	private bool alreadyPut = false ;
	private bool alreadyPutGem = false ;

	private int slotOcupied = 0 ;
	private bool gemInventoryIsFull = false;

	private int slotOcupiedI = 0 ;
	private bool inventoryIsFull = false ;

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

		Debug.Log(inventoryIsFull) ;
	}

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("hey") ;

            if (hit.collider.transform.gameObject.layer == 10)
            {                
               Open_Description_Window(hit);
            }
            else
            {
                Close_Description_Window();
            }
        }
        else
        {
            Close_Description_Window();
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

    void Open_Description_Window(RaycastHit receive_Hit)
    {
        ScriptableItem temp = receive_Hit.transform.GetComponent<ItemApplication>().ReturnScriptable();
        item_Name.text = temp.itemName;
        if (temp.atkBoost > 0 || temp.hPBoost > 0)
        {
            stats_Name.text = "Atk +" + temp.atkBoost + "\nHp +" + temp.hPBoost;
        }
        item_Info_Window.SetActive(true);
        item_Info_Window.transform.position = Input.mousePosition + new Vector3(50, 40, 0);
    }

    void Close_Description_Window()
    {
        item_Info_Window.SetActive(false);
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
				if(associateScriptable.atkBoost > 0)
				{
					GameObject.FindGameObjectWithTag("Player").GetComponent<Wilfried_Moves>().UpAtk(associateScriptable.atkBoost) ;
				}
				if(associateScriptable.hPBoost > 0)
				{
					GameObject.FindGameObjectWithTag("Player").GetComponent<Wilfried_Moves>().AddMaxHp(associateScriptable.hPBoost) ;
				}
				gemSlot[i].GetComponent<InventoryGemSystem>().AddGemToSlot(associateScriptable,i) ;
				gemEquip[i] = associateScriptable ;
				alreadyPutGem = true ;
				objectInSlot[slotUse] = null ;
			}
		}
	}

	public void RetireGem(int slotToUse, ScriptableItem script)
	{
		gemEquip[slotToUse] = null ;

		alreadyPut = false ;

		//Debug.Log("Input") ;

		for(int i = 0 ; i < slot.Length ; i++)
		{
			//Debug.Log("Boucle") ;
			if(objectInSlot[i] == null && !alreadyPut)
			{
				//Debug.Log("Condition") ;
				if(script.atkBoost > 0)
				{
					GameObject.FindGameObjectWithTag("Player").GetComponent<Wilfried_Moves>().DownAtk(script.atkBoost) ;
				}
				if(script.hPBoost > 0)
				{
					GameObject.FindGameObjectWithTag("Player").GetComponent<Wilfried_Moves>().RetireMaxHp(script.hPBoost) ;
				}
				slot[i].GetComponent<InventorySlot>().AddObjectToSlot(script,i) ;
				objectInSlot[i] = script ;
				alreadyPut = true ;
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

		public bool CheckIfFull()
	{
		slotOcupiedI = 0 ;

		for(int i = 0 ; i < slot.Length ; i++)
		{
			if(objectInSlot[i] != null)
			{
				slotOcupied++ ;
			}
		}

		if(slotOcupiedI >= objectInSlot.Length)
		{
			inventoryIsFull = true ;
		}
		else
		{
			inventoryIsFull = false ;
		}

		return inventoryIsFull ;
	}
}
