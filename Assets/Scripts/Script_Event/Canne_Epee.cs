using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Canne_Epee : MonoBehaviour {

    public Image canne;
    public float coolDownMax;
    public Button buttonCanne;
    public float range;
    Raycast hit;

    private float currentCoolDown = 0;

   
    void Start()
    {
       
        currentCoolDown = coolDownMax;

    }
    // Update is called once per frame
    void Update()  //gestion du cooldown
    {
        if (currentCoolDown <= coolDownMax)
        {
            currentCoolDown += Time.deltaTime;
            canne.fillAmount = currentCoolDown / coolDownMax;
        }
        else if (currentCoolDown >= coolDownMax)
        {
            currentCoolDown = coolDownMax;
            buttonCanne.interactable = true;
        }

    }
    public void Arme() //frapper
    {
        canne.fillAmount = 0;
        currentCoolDown = 0;
        buttonCanne.interactable = false;
        GetComponent<AudioSource>().Play();

        //Debug.DrawRay(transform.position, Vector3.forward * range, Color.green);
        //if (Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.CompareTag == "Enemy")
        //{
       // Debug.Log("testdebug");

       // }
    }

}
