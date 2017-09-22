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
    public LayerMask ennemy;
    public GameObject wilfredCam;
    public float damage;

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

        RaycastHit hit;
        if (Physics.Raycast(wilfredCam.transform.position, wilfredCam.transform.forward, out hit, range, ennemy))
        {
            TargetDamage target = hit.transform.GetComponent<TargetDamage>();
            Debug.Log(hit.transform.name);
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

}
