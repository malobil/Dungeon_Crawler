using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_script : MonoBehaviour 
{

	private bool isOcupiedByPlayer = false ;

	public List<GameObject> waypoints = new List<GameObject>() ;
	private float raycastRange = 1 ;

	// Use this for initialization
	void Start () 
	{
		CheckVoisin() ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void CheckVoisin()
	{
		RaycastHit frontHit ;
		RaycastHit backHit ;
		RaycastHit leftHit ;
		RaycastHit rightHit ;

		//Check forward//
		if(Physics.Raycast(transform.position,transform.forward,out frontHit,raycastRange))
		{
			//Debug.Log(frontHit.transform.gameObject.layer) ;
			if(frontHit.transform.gameObject.layer == 8)
			{
				//Debug.Log("Hit") ;
				waypoints.Add(frontHit.transform.gameObject) ;
				
				//Debug.Log(frontWayPoint) ;
			}
		}

		//Check backward//
		if(Physics.Raycast(transform.position,-transform.forward,out backHit,raycastRange))
		{
			if(backHit.transform.gameObject.layer == 8)
			{
				//Debug.Log("Hit") ;
				waypoints.Add(backHit.transform.gameObject) ;
				//Debug.Log(backWayPoint) ;
			}
		}


		//Check left//
		if(Physics.Raycast(transform.position,-transform.right,out leftHit,raycastRange))
		{
			if(leftHit.transform.gameObject.layer == 8)
			{
				//Debug.Log("Hit") ;
				waypoints.Add(leftHit.transform.gameObject) ;
				//Debug.Log(leftWayPoint) ;
			}
		}

		//Check right//
		if(Physics.Raycast(transform.position,transform.right,out rightHit,raycastRange))
		{
			if(rightHit.transform.gameObject.layer == 8)
			{
				//Debug.Log("Hit") ;
				waypoints.Add(rightHit.transform.gameObject) ;
				//Debug.Log(rightWayPoint) ;
			}
		
		}
	}

	public bool ReturnIsOcupiedByPlayer()
	{
		return isOcupiedByPlayer ;
	}

	public List<GameObject> ReturnWayPoint()
	{
		return waypoints ;
	}



	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			isOcupiedByPlayer = true ;
			//gameObject.SetActive(false) ;
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		
			isOcupiedByPlayer = false ;
			gameObject.SetActive(true) ;
	}

}
