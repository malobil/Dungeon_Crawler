using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wilfried_HP : MonoBehaviour {

    public Image healthBar;
    public float wilfried_current_HP;
    public float wilfried_max_HP;
    public float wilfried_min_HP;
    public float damages_To_Wilfried;
    public Text hp;
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
        hp.text = wilfried_current_HP.ToString() + "/" + wilfried_max_HP.ToString();
        if (Input.GetKeyDown("m") & wilfried_current_HP > wilfried_min_HP)
        {   //Lorsque joueur appuie sur la touche "m"
            wilfried_current_HP = wilfried_current_HP - damages_To_Wilfried;
            LifeManager();
        }
	}
}