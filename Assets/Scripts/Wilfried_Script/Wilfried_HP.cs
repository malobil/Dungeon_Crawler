using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wilfried_HP : MonoBehaviour {

    public Image healthBar;
    public float wilfried_current_HP;
    public float wilfried_max_HP;
    public float wilfried_min_HP;
    public float damages_to_wilfried;
    public float heal_wilfried;
    //public Text hp;
    public GameObject inventory;

    public bool isGemmeEquiped = false;
    public float gemme_HP_plus;

	// Use this for initialization
	void Start () {
        LifeManager();
	}

    public void LifeManager()
    {
        healthBar.fillAmount = wilfried_current_HP / wilfried_max_HP;
    }
	
	// Update is called once per frame
	void Update () {
       // hp.text = wilfried_current_HP.ToString() + "/" + wilfried_max_HP.ToString();
        if (Input.GetKeyDown("m") & wilfried_current_HP > wilfried_min_HP)
        {   //Lorsque joueur appuie sur la touche "m", il perd 10HP
        	GetComponent<AudioSource>().Play();
            wilfried_current_HP = wilfried_current_HP - damages_to_wilfried;
            LifeManager();
        }
        if (Input.GetKeyDown("l") & wilfried_current_HP < wilfried_max_HP)
        {   //Lorsque joueur appuie sur touche "l", il gagne 10HP
            wilfried_current_HP = wilfried_current_HP + heal_wilfried;
            LifeManager();
        }
        if (Input.GetKeyDown("g")){ //Lorsque le joueur appuie sur G, il equipe ou desequipe une gemme qui lui donne +10 en HP max
        	if (isGemmeEquiped == false){
        		wilfried_max_HP += gemme_HP_plus;
        		LifeManager();
        		isGemmeEquiped = true;
        	} else if (isGemmeEquiped == true){
        		if (wilfried_current_HP >= wilfried_max_HP - gemme_HP_plus){
        			wilfried_max_HP -= gemme_HP_plus;
        			wilfried_current_HP = wilfried_max_HP;
        			LifeManager();
        		} else if (wilfried_current_HP < wilfried_max_HP - gemme_HP_plus){
        			wilfried_max_HP -= gemme_HP_plus;
        			LifeManager();
        		}
        		isGemmeEquiped = false;
        	}
        }
	}

    public void Open_Inventory()
    {
        inventory.SetActive(true);
    }

    public void Close_Inventory()
    {
        inventory.SetActive(false);
    }

}