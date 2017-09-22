using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_PathFinding : MonoBehaviour {

	public float movementSpeed = 5 ;
	public float moveCooldown ;

	public float atackSpeed ;
	private float currentAttackCd ;
	public float damage ;

	public Animator animatorComponent ;
	private float currentMoveCoolDown ;

	private bool haveFindPlayer = false ;
	private int turn = 0 ;

	private GameObject frontWayPoint ;
	private GameObject backWayPoint ;
	private GameObject leftWayPoint ;
	private GameObject rightWayPoint ;
	private GameObject currentWayPoint ;

	private float tempFrontDistance,tempBackDistance,tempLeftDistance,tempRigthDistance,tempCurrentDistance ;
	private List<float> distanceList = new List<float>() ;
	private float nearestWp ;
	private GameObject distanceToGo ;

	private GameObject player ;

	private float raycastRange = 200 ;

	private bool nearPlayer = false ;
	private bool canMove = true ;
	// Use this for initialization
	void Start () 
	{	
		currentMoveCoolDown = moveCooldown ;
		player = GameObject.FindGameObjectWithTag("Player") ;
		CheckNearWaypoint() ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentMoveCoolDown > 0)
		{
			currentMoveCoolDown -= Time.deltaTime ;
		}
		if(currentMoveCoolDown <= 0)
		{
			currentMoveCoolDown = moveCooldown ;
			PathFinding() ;
		}

		if(currentAttackCd > 0 )
		{
			currentAttackCd -= Time.deltaTime ;
			animatorComponent.SetTrigger("StopAttack") ;
		}
		if(currentAttackCd <= 0 && nearPlayer)
		{
			animatorComponent.SetTrigger("Attack") ;
			currentAttackCd = atackSpeed ;
			transform.LookAt(player.transform) ;
		}

		/*if(Input.GetKeyDown("f"))
		{
			PathFinding() ;
		}*/

		if(distanceToGo != null && transform.position != distanceToGo.transform.position && !nearPlayer)
		{
			transform.position = Vector3.MoveTowards(transform.position, distanceToGo.transform.position, movementSpeed * Time.deltaTime) ;
			transform.LookAt(distanceToGo.transform) ;
			animatorComponent.SetTrigger("Move") ;
		}
		else if(transform.position == currentWayPoint.transform.position)
		{
			animatorComponent.SetTrigger("StopMove") ;
		}
	}

	void PathFinding()
	{	
		nearPlayer = false ;
		CheckNearWaypoint() ;
		distanceList.Clear() ;
		tempCurrentDistance = Vector3.Distance(currentWayPoint.transform.position, player.transform.position) ;
		distanceList.Add(tempCurrentDistance) ;
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

			
				if(nearestWp == tempRigthDistance && rightWayPoint != null)
				{
					if(!rightWayPoint.GetComponent<Waypoint_script>().ReturnIsOcupiedByPlayer())
					{
						distanceToGo = rightWayPoint ;
					}
				}
				if(nearestWp == tempFrontDistance && frontWayPoint!=null)
				{
					if(!frontWayPoint.GetComponent<Waypoint_script>().ReturnIsOcupiedByPlayer())
					{
						distanceToGo = frontWayPoint ;
					}
				}
				if(nearestWp == tempLeftDistance && leftWayPoint!=null)
				{
					if(!leftWayPoint.GetComponent<Waypoint_script>().ReturnIsOcupiedByPlayer())
					{
						distanceToGo = leftWayPoint ;
					}
				}
				if(nearestWp == tempBackDistance && backWayPoint !=null)
				{	
					if(!backWayPoint.GetComponent<Waypoint_script>().ReturnIsOcupiedByPlayer())
					{
						distanceToGo = backWayPoint ;
					}
				}
				if(nearestWp == tempCurrentDistance)
				{
					distanceToGo = currentWayPoint ;
					nearPlayer = true ;

				}
		}
		

		//Debug.Log("distance" + distanceToGo) ;	

	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Collider>().transform.gameObject.layer == 8)
		{
			currentWayPoint = other.gameObject ;
		}
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
				nearPlayer = false ;
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
