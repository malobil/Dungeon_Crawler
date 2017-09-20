using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wilfried_HP : MonoBehaviour {

    public Image healthBar;
    public float wilfried_current_HP;
    public float wilfried_max_HP;
    public float damages_To_Wilfried;
   
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
        if (Input.GetKeyDown("m"))
        {   //Lorsque joueur appuie sur la touche "m"
            wilfried_current_HP = wilfried_current_HP - damages_To_Wilfried;
            LifeManager();
        }
	}
}
