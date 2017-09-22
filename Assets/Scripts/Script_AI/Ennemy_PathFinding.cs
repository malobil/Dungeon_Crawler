using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_PathFinding : MonoBehaviour {

	public float movementSpeed = 5 ;

	private bool haveFindPlayer = false ;
	private int turn = 0 ;

	private GameObject frontWayPoint ;
	private GameObject backWayPoint ;
	private GameObject leftWayPoint ;
	private GameObject rightWayPoint ;

	private float tempFrontDistance,tempBackDistance,tempLeftDistance,tempRigthDistance ;
	public List<float> distanceList = new List<float>() ;
	private float nearestWp ;
	private GameObject distanceToGo ;

	private GameObject player ;

	public float raycastRange = 1 ;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player") ;
		CheckNearWaypoint() ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("f"))
		{
			PathFinding() ;
		}

		if(distanceToGo != null && transform.position != distanceToGo.transform.position)
		{
			transform.position = Vector3.MoveTowards(transform.position, distanceToGo.transform.position, movementSpeed * Time.deltaTime) ;
		}
	}

	void PathFinding()
	{	
		CheckNearWaypoint() ;
		distanceList.Clear() ;
		if(frontWayPoint != null)
		{
			tempFrontDistance = Vector3.Distance(frontWayPoint.transform.position, player.transform.position) ;
			distanceList.Add(tempFrontDistance) ;
			//Debug.Log(tempFrontDistance) ;
		}
		if(backWayPoint != null)
		{
			tempBackDistance = Vector3.Distance(backWayPoint.transform.position, player.transform.position) ;
			distanceList.Add(tempBackDistance) ;
			//Debug.Log(tempBackDistance) ;
		}
		if(leftWayPoint != null)
		{
			tempLeftDistance = Vector3.Distance(leftWayPoint.transform.position, player.transform.position) ;
			distanceList.Add(tempLeftDistance) ;
			//Debug.Log(tempLeftDistance) ;
		}
		if(rightWayPoint != null)
		{
			tempRigthDistance = Vector3.Distance(rightWayPoint.transform.position, player.transform.position) ; 
			distanceList.Add(tempRigthDistance) ;
			//Debug.Log("if" + tempRigthDistance) ;
		}

		Debug.Log("end if r " + tempRigthDistance) ;
		Debug.Log("end if l " + tempLeftDistance) ;
		Debug.Log("end if f  " + tempFrontDistance) ;
		Debug.Log("end if b " + tempBackDistance) ;

		for(int i = 0 ; i < distanceList.Count ; i++)
		{
			if(i ==0)
			{
				nearestWp = distanceList[i] ;
			}
			if(distanceList[i] < nearestWp)
			{
				nearestWp = distanceList[i] ;
			}
		}

		Debug.Log("near" + nearestWp) ;
		
		if(nearestWp == tempRigthDistance)
		{
			distanceToGo = rightWayPoint ;
		}
		if(nearestWp == tempFrontDistance)
		{
			distanceToGo = frontWayPoint ;	
		}
		if(nearestWp == tempLeftDistance)
		{
			distanceToGo = leftWayPoint ;
		}
		if(nearestWp == tempBackDistance)
		{
			distanceToGo = backWayPoint ;
		}

		//Debug.Log("distance" + distanceToGo) ;	
	}


	void CheckNearWaypoint()
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
				frontWayPoint = frontHit.transform.gameObject ;
				//Debug.Log(frontWayPoint) ;
			}
			else
			{
				frontWayPoint = null ;
			}
		}
		else
		{
			frontWayPoint = null ;
		}

		//Check backward//
		if(Physics.Raycast(transform.position,-transform.forward,out backHit,raycastRange))
		{
			if(backHit.transform.gameObject.layer == 8)
			{
				//Debug.Log("Hit") ;
				backWayPoint = backHit.transform.gameObject ;
				//Debug.Log(backWayPoint) ;
			}
			else
			{
				backWayPoint = null ;	
			}
		}
		else
		{
			backWayPoint = null ;
		}

		//Check left//
		if(Physics.Raycast(transform.position,-transform.right,out leftHit,raycastRange))
		{
			if(leftHit.transform.gameObject.layer == 8)
			{
				//Debug.Log("Hit") ;
				leftWayPoint = leftHit.transform.gameObject ;
				//Debug.Log(leftWayPoint) ;
			}
			else
			{
				leftWayPoint = null ;
			}
		}
		else
		{
			leftWayPoint = null ;
		}

		//Check right//
		if(Physics.Raycast(transform.position,transform.right,out rightHit,raycastRange))
		{
			if(rightHit.transform.gameObject.layer == 8)
			{
				//Debug.Log("Hit") ;
				rightWayPoint = rightHit.transform.gameObject ;
				//Debug.Log(rightWayPoint) ;
			}
			else 
			{
				rightWayPoint = null ;
			}
		}
		else
		{
			rightWayPoint = null ;
		}
	}
}
