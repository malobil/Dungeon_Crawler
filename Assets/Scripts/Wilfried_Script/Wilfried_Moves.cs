using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wilfried_Moves : MonoBehaviour {

	public float raycastRange ; // range of raycast
	public LayerMask layer ; // waypoint layer
	public float movementSpeed ; // player's speed
	public float rotationSpeed ;

	private Vector3 frontWayPoint ; // the front direction point
	private Vector3 backWayPoint ; // the back direction point
	private Vector3 leftWayPoint ; // the left direction point
	private Vector3 rightWayPoint ; // the right direction point

	private Vector3 destination ; // player's destination

	private bool haveFrontPoint ; // check if you can go forward
	private bool haveBackPoint ; // check if you can go backward
	private bool haveLeftPoint;	// check if you can go left
	private bool haveRightPoint ;	// check if you can go right

	private bool isMoving = false ; // check if the player is curently moving

	private float currentRotation ;
	private Quaternion qTo = Quaternion.identity ;


	// Use this for initialization
	void Start () 
	{
		destination = transform.position ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("z") && haveFrontPoint && !isMoving)
		{
			//isMoving = true ;
			destination = frontWayPoint ;
		}

		if(Input.GetKeyDown("s") && haveBackPoint && !isMoving)
		{
			//isMoving = true ;
			destination = backWayPoint ;
		}

		if(Input.GetKeyDown("q") && haveLeftPoint && !isMoving)
		{
			//isMoving = true ;
			destination = leftWayPoint ;
		}

		if(Input.GetKeyDown("d") && haveRightPoint && !isMoving)
		{
			//isMoving = true ;
			destination = rightWayPoint ;
		}

		if(Input.GetKeyDown("a"))
		{
			currentRotation -= 90 ;
			qTo = Quaternion.Euler(0,currentRotation,0) ;
		}

		if(Input.GetKeyDown("e"))
		{	
			currentRotation += 90 ;
			qTo = Quaternion.Euler(0,currentRotation,0) ;
		}

		
		Move() ;
		

		TurnCamera() ;
	}

	void FixedUpdate()
	{	
		//Debug
		/*Debug.DrawRay(transform.position,Vector3.forward * raycastRange,Color.green) ;
		Debug.DrawRay(transform.position,Vector3.back * raycastRange,Color.green) ;
		Debug.DrawRay(transform.position,Vector3.left * raycastRange,Color.green) ;
		Debug.DrawRay(transform.position,Vector3.right * raycastRange,Color.green) ;*/

		RaycastHit frontHit ;
		RaycastHit backHit ;
		RaycastHit leftHit ;
		RaycastHit rightHit ;

		//Shot a ray in 4 direction to check if got a wayPoint //

		//Check forward//
		if(Physics.Raycast(transform.position,transform.forward,out frontHit,raycastRange,layer))
		{
			//Debug.Log("Hit") ;
			frontWayPoint = frontHit.transform.position ;
			haveFrontPoint = true ;
			//Debug.Log(frontWayPoint) ;
		}
		else
		{
			haveFrontPoint = false ;
		}

		//Check backward//
		if(Physics.Raycast(transform.position,-transform.forward,out backHit,raycastRange,layer))
		{
			//Debug.Log("Hit") ;
			backWayPoint = backHit.transform.position ;
			haveBackPoint = true ;
			//Debug.Log(backWayPoint) ;
		}
		else
		{
			haveBackPoint = false ;
		}

		//Check left//
		if(Physics.Raycast(transform.position,-transform.right,out leftHit,raycastRange,layer))
		{
			//Debug.Log("Hit") ;
			leftWayPoint = leftHit.transform.position ;
			haveLeftPoint = true ;
			//Debug.Log(leftWayPoint) ;
		}
		else
		{
			haveLeftPoint = false ;
		}

		//Check right//
		if(Physics.Raycast(transform.position,transform.right,out rightHit,raycastRange,layer))
		{
			//Debug.Log("Hit") ;
			rightWayPoint = rightHit.transform.position ;
			haveRightPoint = true ;
			//Debug.Log(rightWayPoint) ;
		}
		else
		{
			haveRightPoint = false ;
		}
	}

	//Move the player to a destination
	void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime) ;
	}

	//turn the camera left or right//
	void TurnCamera()
	{
		transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotationSpeed * Time.deltaTime) ;
	}

	public Vector3 ReturnFrontWayPoint()
	{
		return frontWayPoint ;
	}

	public Vector3 ReturnBackWayPoint()
	{
		return backWayPoint ;
	}

	public Vector3 ReturnLeftWayPoint()
	{
		return leftWayPoint ;
	}

	public Vector3 ReturnRightWayPoint()
	{
		return rightWayPoint ;
	}

}
