// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using System;

// public class UI_ManagerFinal : MonoBehaviour {

// 	private float totalCount = 0f ; // Barre_Score
// 	public float addCount; // Score ajouté au Score quand on appuie sur Bouton_Prod
// 	public Text countText ; // Texte de Barre_Score 
// 	public Text countPerMinute ; // Texte de Barre_Score/min
// 	public float cdTime ; // Temps en seconde du décompte de Barre_Score/min avant d'ajouter sa valeur à Barre_Score
// 	private float actualCD ; // Variable qui va servir de cooldown
// 	public float countAddPerMinute ; // Variable du score qui va s'ajouter chaque minutes à Barre_Score
// 	public Text scoreAdvancement; // Texte de Barre_Objectif
// 	public float scoreAdvancing; // Variable de Barre_Objectif correspondant au Score total
// 	public float scoreToAdvance; // Variable de Barre_Objectif correspondant à l'objectif à atteindre
// 	public bool lvlUp = false; // Est-ce que le bouton +2 est actif ou non 
// 	public float priceMultiplier; // Multiplieur de prix à chaque amélioration
// 	public float scoreMultiplier; // Multiplieur de score à chaque amélioration
// 	public Text plusButton ; // Texte de Bouton_Augmentation
// 	private float secretCD = 0f ; // Variable d'augmentation de Bouton_Augmentation (+2 +3 +4)
// 	public float secretCDInterval ; // Variable requise pour augmenter le Bouton_Augmentation
// 	public int[] itemInShop ; // Tableau d'items du shop
// 	private bool checkSave=false; 

// 	public GameObject power ;
// 	private bool buybuy = true;
//     public Image cooldown;
//    	private bool coolingDown = false;
//     public float waitTime;

//     public Button buttonboost;
//     public float countMultiplier;
//     public GameObject menuPause;
//     private bool countAPMB; // count add per minute during *2 boost 
//     private bool aventureActiv;
//     public float timerSecondes;
//     public float timerMinutes;
//     public float timerHeures;
//     private float waittimeM = 1.0f;
//     private bool stoptimer = false;
//     public GameObject layoutmission;
//     public Text decompte;
//     private bool aventureOK;
//     public Button buttonBuy;
//     public GameObject aventures;
//     private float currentReward;
//     public GameObject prefab;
//     public float timeprefab;
//     private float timeprefabReset = 3f;
//     private float nbmaxprefab =0f;
//     private bool timerOK;
//     public GameObject tempTimer;
//     public GameObject boutonAnnuler;
//     public GameObject boutonInfo;
//     public GameObject popUp;
//     public GameObject popupInfo;
//     private bool popUpAventureActiv = false;
//     private float timeSecondPass;
//     private float timeSecond;
//     public Text popupnommission;
//     public Text popuprecompense;
//     private bool boostActiv;
//     public Image timerBarre;
//     public GameObject lancageMission;

//     private float hoursAventure;
//     private float prixAventure;
//     private float secondesAventure;
//     private float minutesAventure;
//     private float rewardAventure;
//     private string nameAventure;

//     public Text lancerAventure;
//     private GameObject laVenture;
//     public List<ScriptableMission> popRandom = new List<ScriptableMission>();


// 	// Use this for initialization
// 	void Start () {
// 		actualCD = cdTime;
// 		TotalChange();
// 		SPMChange();

// 	}

	
// 	// Update is called once per frame
// 	void Update () 
// 	{
// 		if (Input.GetKeyDown("escape"))
// 		{
// 			Escape();	
//         }

//         if (Input.GetKeyDown("f"))
// 		{
// 			Prefabmission();
//         }

// 		Bonustimer();
// 		CoolDown();
// 		ScoreAdvance();
// 		SPMPlusButton();
// 		PlusButtonChange();
// 		Buy();
// 		Missiontimer();
// 		Aventure ();

// 	}

// 	// CLick de Bouton_Prod
// 	public void OnClick () {
// 		totalCount = totalCount + addCount ;
// 		TotalChange();
// 	}

// 	// Cooldown pour Bouton_Score/min
// 	void CoolDown () 
// 	{
// 		 actualCD -= Time.deltaTime;
//          if(actualCD < 0)
//          {
// 			totalCount = totalCount + (countAddPerMinute / 60f) ;
// //			Debug.Log(totalCount) ;
// 			actualCD = cdTime;
// 			TotalChange();
//          }
// 	}
// 	// Recharger texte de Barre_Score
// 	void TotalChange () {
// 		countText.text = totalCount.ToString("F0");
// 	}
// 	// Recharger texte de Barre_Score/min
// 	void SPMChange () {
// 		countPerMinute.text = countAddPerMinute.ToString("F0") + " / m";
// 	}
// 	// Recharger texte de Barre_Objectif
// 	void SAChange () {
// 		scoreAdvancement.text = scoreAdvancing.ToString("F0") + " / " + Mathf.RoundToInt(scoreToAdvance).ToString("F0");
// 	}
// 	// Recharger texte de Bouton_Augmantation
// 	void PlusButtonChange () {
// 		plusButton.text = "+ " + scoreMultiplier.ToString();
// 	}

// 	// Code de Barre_Objectif
// 	void ScoreAdvance () {
// 		scoreAdvancing = totalCount;
// 		if (scoreAdvancing >= scoreToAdvance)
// 			{
// 				scoreAdvancing = Mathf.RoundToInt(scoreToAdvance);
// 				lvlUp = true;
// 			}
// 		else if (scoreAdvancing <= scoreToAdvance)
// 			{
// 				lvlUp = false;
// 			}
// 			SAChange();
// 	}
// 	// Code de Barre_Score/min
// 	public void SPMAdvance()
//     {
//         if (lvlUp == true)
//         {
//             totalCount -= Mathf.FloorToInt(scoreToAdvance);
//             scoreToAdvance *= priceMultiplier;
//             addCount +=scoreMultiplier;

//             if (coolingDown == true)
//             {
//                 countAddPerMinute += scoreMultiplier * countMultiplier;
//             }
//             else if (coolingDown == false)
//             {
//                 countAddPerMinute += scoreMultiplier;
//             }

//             secretCD += 1;
//             lvlUp = false;
//             TotalChange();
//             SPMChange();
//         }
//     }
// 	// Code de Bouton_Augmentation
// 	void SPMPlusButton () {
// 		if (secretCD == secretCDInterval) 
// 			{
// 				scoreMultiplier += 1;
// 				secretCD = 0;
// 			}
// 	}
// 	// Code de Layout_Boutique


// 	 void Buy ()
// 	{
// 		if(totalCount >= 5000 ) 
// 			{
// 				power.SetActive(true) ;
// 				boostActiv = true;
// 			}

// 		if(boostActiv == true)
// 		{
// 			power.SetActive(true);
// 		}
// 	}

// 	public void BoostActive ()
// 	{
		
// 		if (totalCount >= 50)
// 		{
// 			totalCount -= 50f;
// 			TotalChange ();
// 			countAddPerMinute = countAddPerMinute * countMultiplier;
// 			SPMChange();
// 			coolingDown = true;		
// 		}	
// 	}




// 	void Bonustimer ()
// 	{
// 		if (coolingDown == true)
//        	{
//             cooldown.fillAmount -= (1.0f / waitTime) * Time.deltaTime;
//             buttonboost.interactable = false;
// 		}

// 		if (cooldown.fillAmount <= 0f)
// 		{
// 		 	coolingDown = false;
// 		 	countAddPerMinute /= 2f;
// 		 	SPMChange();
// 		}

// 		if (coolingDown == false)
// 		{
// 			cooldown.fillAmount = waitTime;
// 			buttonboost.interactable = true;
// 		}
// 	}

// 	void Missiontimer ()
// 	{

// 		if(timerHeures < 0)
// 		{
// 			timerHeures = 0;
// 		}

// 		if(timerMinutes < 0)
// 		{
// 			timerMinutes = 0;
// 		}

// 		if(timerSecondes < 0)
// 		{
// 			timerSecondes = 0;
// 		}


// 		if(timerHeures == 0 && timerMinutes == 0 && timerSecondes == 0 && aventureOK)
// 		{
// 			totalCount += currentReward;
// 			currentReward = 0;
// 			nbmaxprefab-- ;
// 			TotalChange();
// 			aventureOK = false;
// 			timerBarre.fillAmount = 0;
// 			boutonInfo.SetActive(false);
// 			boutonAnnuler.SetActive(false);
// 			tempTimer.SetActive(false);
// 			Destroy(laVenture);

// 		}

// 		if (timerSecondes > 0)
// 		{
// 			timerSecondes -= Time.deltaTime;
// 			timeSecondPass += Time.deltaTime;

// 			timerBarre.fillAmount += ((1.0f / timeSecond ) * Time.deltaTime) ;
			

// 			popuprecompense.text = "Récompense : " + ((currentReward /  Mathf.RoundToInt(timeSecond))* Mathf.RoundToInt(timeSecondPass)).ToString("F0");
// 		}

// 		if (timerMinutes >= 1 && timerSecondes == 0)
// 		{
// 			timerSecondes = 59.0f;
// 			timerMinutes--;

// 		}

// 		if (timerHeures > 0 && timerMinutes == 0)
// 		{
// 			timerMinutes = 59.0f;
// 			timerHeures--;
// 		}
// 		AffichageTimer();
// 	}

// 	void AffichageTimer () 
// 	{
// 		decompte.text = timerHeures.ToString("F0") + " H " + timerMinutes.ToString("F0") + " m " + timerSecondes.ToString("F0") + " s ";
// 	}


// 	void Escape ()
// 	{
// 		 menuPause.SetActive(true);
// 	}
	
// 	public void ButtonPauseYes ()
// 	{		 
// 		Application.Quit();
// 	}
	
// 	public void ButtonPauseNo ()
// 	{
// 		menuPause.SetActive(false);	    

// 	}

// 	void Aventure ()
// 	{
// 		if(totalCount >= 2500) 
// 		{
// 			aventures.SetActive(true) ;
// 			aventureActiv = true;
// 		}

// 		if(aventureActiv == true)
// 		{
// 			aventures.SetActive(true);
// 		}
// 	}


// 	void Prefabmission ()
// 	{
// 		if (aventureActiv == true)
// 		{
// 		 if (nbmaxprefab < 2) {

// 		 	int tempory = UnityEngine.Random.Range(0,popRandom.Count) ;
// 		 	prefab.GetComponent<MissionAplication>().my_scriptable = popRandom[tempory];
// 			Instantiate(prefab, layoutmission.transform);
//         	nbmaxprefab += 1f;

// 			}
// 		}
// 	}

// 	public void SaveGame () {
// 		checkSave =true ;
// 		PlayerPrefs.SetFloat("Score Total", totalCount);
// 		PlayerPrefs.SetFloat("cdTime", cdTime);
// 		PlayerPrefs.SetFloat("Score per minute", countAddPerMinute);
// 		PlayerPrefs.SetFloat("scoreAdvancing", scoreAdvancing);
// 		PlayerPrefs.SetFloat("scoreToAdvance", scoreToAdvance);
// 		PlayerPrefs.SetInt("levelup",lvlUp ? 1 : 0);
// 		PlayerPrefs.SetFloat("priceMultiplier", priceMultiplier);
// 		PlayerPrefs.SetFloat("scoreMultiplier", scoreMultiplier);
// 		PlayerPrefs.SetFloat("secretCD", secretCD);
// 		PlayerPrefs.SetFloat("secretCDInterval", secretCDInterval);
// 		PlayerPrefs.SetInt("buybuy",buybuy ? 1 : 0);
// 		PlayerPrefs.SetInt("coolingDown",coolingDown ? 1 : 0);
// 		PlayerPrefs.SetFloat("waitTime", waitTime);
// 		PlayerPrefs.SetFloat("countMultiplier", countMultiplier);
// 		PlayerPrefs.SetInt("countAPMB", countAPMB ? 1 : 0);
// 		PlayerPrefs.SetFloat("timerSecondes", timerSecondes);
// 		PlayerPrefs.SetFloat("timerMinutes", timerMinutes);
// 		PlayerPrefs.SetFloat("timerHeures", timerHeures);
// 		PlayerPrefs.SetFloat("waittimeM", waittimeM);
// 		PlayerPrefs.SetInt("stoptimer", stoptimer ? 1 : 0);
// 		PlayerPrefs.SetFloat("timeprefab", timeprefab);
// 		PlayerPrefs.SetFloat("timeprefabReset", timeprefabReset);
// 		PlayerPrefs.SetInt("boostActiv", boostActiv ? 1 : 0);
// 		PlayerPrefs.SetInt("aventureActiv", aventureActiv ? 1 : 0);
// 		PlayerPrefs.SetFloat("addCount", addCount);
// 		PlayerPrefs.SetInt("checkIfSave",checkSave ? 1 : 0);

// 	}

// 	public void LoadGame () {
// 		if (Convert.ToBoolean(PlayerPrefs.GetInt("checkIfSave"))== true)
// 		{
// 		totalCount = PlayerPrefs.GetFloat("Score Total");
// 		cdTime = PlayerPrefs.GetFloat("cdTime");
// 		countAddPerMinute = PlayerPrefs.GetFloat("Score per minute");
// 		scoreAdvancing = PlayerPrefs.GetFloat("scoreAdvancing");
// 		scoreToAdvance = PlayerPrefs.GetFloat("scoreToAdvance");
// 		lvlUp = Convert.ToBoolean(PlayerPrefs.GetInt("levelup"));
// 		priceMultiplier = PlayerPrefs.GetFloat("priceMultiplier");
// 		scoreMultiplier = PlayerPrefs.GetFloat("scoreMultiplier");
// 		secretCD = PlayerPrefs.GetFloat("secretCD");
// 		secretCDInterval = PlayerPrefs.GetFloat("secretCDInterval");
// 		buybuy = Convert.ToBoolean(PlayerPrefs.GetInt("buybuy"));
// 		coolingDown = Convert.ToBoolean(PlayerPrefs.GetInt("coolingDown"));
// 		waitTime = PlayerPrefs.GetFloat("waitTime");
// 		countMultiplier = PlayerPrefs.GetFloat("countMultiplier");
// 		countAPMB = Convert.ToBoolean(PlayerPrefs.GetInt("countAPMB"));
// 		timerSecondes = PlayerPrefs.GetFloat("timerSecondes");
// 		timerMinutes = PlayerPrefs.GetFloat("timerMinutes");
// 		timerHeures = PlayerPrefs.GetFloat("timerHeures");
// 		waittimeM = PlayerPrefs.GetFloat("waittimeM");
// 		stoptimer = Convert.ToBoolean(PlayerPrefs.GetInt("stoptimer"));
// 		timeprefab = PlayerPrefs.GetFloat("timeprefab");
// 		timeprefabReset = PlayerPrefs.GetFloat("timeprefabReset");
// 		boostActiv = Convert.ToBoolean(PlayerPrefs.GetInt("boostActiv"));
// 		addCount = PlayerPrefs.GetFloat("addCount");
// 		aventureActiv = Convert.ToBoolean(PlayerPrefs.GetInt("aventureActiv"));
// 		}


// 		TotalChange();
// 		SPMChange();
// 		SAChange();
// 		PlusButtonChange();
// 	}

// 	public void SetTimerAventure (float hours, float minutes, float secondes, float prix, float reward, string name, GameObject monaventure) {

// 		if (totalCount >= prix && !aventureOK)
// 		{
// 			hoursAventure = hours;
// 			minutesAventure = minutes;
// 			secondesAventure = secondes;
// 			prixAventure = prix;
// 			rewardAventure = reward;
// 			nameAventure = name;
// 			lancageMission.SetActive(true);
// 			lancerAventure.text = "Voulez vous commencer l'aventure : \n \n" + nameAventure;
// 			laVenture = monaventure ;
// 		}
// 	}

// 	public void BoutonQuitAventure () {
// 		popUpAventureActiv = !popUpAventureActiv;
// 		popUp.SetActive(popUpAventureActiv);
// 	}

// 	public void BoutonOuiFinAventure () {
// 		totalCount += (currentReward /  Mathf.RoundToInt(timeSecond))* Mathf.RoundToInt(timeSecondPass);
// 		currentReward = 0 ;
// 		timerHeures = 0;
// 		timerSecondes = 0;
// 		timerMinutes = 0;
// 		popUpAventureActiv = !popUpAventureActiv;
// 		popUp.SetActive(popUpAventureActiv);

// 	}

// 	public void BoutonNonAventure () {
// 		popUpAventureActiv = !popUpAventureActiv;
// 		popUp.SetActive(popUpAventureActiv);
// 	}

// 	public void BoutonInfo () {
// 		popupInfo.SetActive(true);

// 	}

// 	public void BoutonOkInfo () {
// 		popupInfo.SetActive(false);
// 	}

// 	public void LanconsLaventureBoutonOu () {

// 		if (totalCount >= prixAventure && !aventureOK)
// 		{
// 			totalCount -= prixAventure;
// 			timerHeures = hoursAventure;
// 			timerMinutes = minutesAventure;
// 			timerSecondes = secondesAventure;
// 			timeSecondPass = 0;
// 			timeSecond = secondesAventure + (minutesAventure*60) + (hoursAventure*3600);
// 			currentReward = rewardAventure;
// 			aventureOK = true;
// 			TotalChange();
// 			boutonInfo.SetActive(true);
// 			boutonAnnuler.SetActive(true);
// 			tempTimer.SetActive(true);
// 			popupnommission.text = "Nom de l'aventure : " + nameAventure;
// 			lancageMission.SetActive(true);
// 			lancageMission.SetActive(false);
// 		}
// 	}

// 	public void boutonNonLancerAventure () {
// 		lancageMission.SetActive(false);
// 	}
// }