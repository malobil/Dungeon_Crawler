using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Stats : MonoBehaviour {

    public float ennemy_current_HP;
    public float ennemy_max_HP;

    public float ennemy_takes_damages_amount;
    public float ennemy_heals_amount;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Ennemy_Takes_Damages()
    {
        ennemy_current_HP = ennemy_current_HP - ennemy_takes_damages_amount;

        if(ennemy_current_HP <= 0)
        {
   
        }
    }

    public void Ennemy_Heals()
    {
        ennemy_current_HP = ennemy_current_HP + ennemy_heals_amount;

        if(ennemy_current_HP > ennemy_max_HP)
        {
            ennemy_current_HP = ennemy_max_HP;
        }
    }
}
