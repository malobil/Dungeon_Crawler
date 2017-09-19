using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wilfried_Moves : MonoBehaviour {

	public float raycastRange ;
	public LayerMask layer ;
	public float movementSpeed ;

	private Vector3 frontWayPoint ;
	private Vector3 backWayPoint ;
	private Vector3 leftWayPoint ;
	private Vector3 rightWayPoint ;

	private bool haveFrontPoint ;
	private bool haveBackPoint ;
	private bool haveLeftPoint;
	private bool haveRightPoint ;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("z") && haveFrontPoint)
		{
			transform.position = Vector3.MoveTowards(transform.position, frontWayPoint, movementSpeed) ;
		}

		if(Input.GetKeyDown("s") && haveBackPoint)
		{
			transform.position = Vector3.MoveTowards(transform.position, backWayPoint, movementSpeed) ;
		}

		if(Input.GetKeyDown("q") && haveLeftPoint)
		{
			transform.position = Vector3.MoveTowards(transform.position, leftWayPoint, movementSpeed) ;
		}

		if(Input.GetKeyDown("d") && haveRightPoint)
		{
			transform.position = Vector3.MoveTowards(transform.position, rightWayPoint, movementSpeed) ;
		}
	}

	void FixedUpdate()
	{	
		//Debug
		Debug.DrawRay(transform.position,Vector3.forward * raycastRange,Color.green) ;
		Debug.DrawRay(transform.position,Vector3.back * raycastRange,Color.green) ;
		Debug.DrawRay(transform.position,Vector3.left * raycastRange,Color.green) ;
		Debug.DrawRay(transform.position,Vector3.right * raycastRange,Color.green) ;

		RaycastHit frontHit ;
		RaycastHit backHit ;
		RaycastHit leftHit ;
		RaycastHit rightHit ;

		//Shot a ray in 4 direction to check if got a wayPoint //
		if(Physics.Raycast(transform.position,Vector3.forward,out frontHit,raycastRange,layer))
		{
			Debug.Log("Hit") ;
			frontWayPoint = frontHit.transform.position ;
			haveFrontPoint = true ;
			Debug.Log(frontWayPoint) ;
		}
		else
		{
			haveFrontPoint = false ;
		}

		if(Physics.Raycast(transform.position,Vector3.back,out backHit,raycastRange,layer))
		{
			Debug.Log("Hit") ;
			backWayPoint = backHit.transform.position ;
			haveBackPoint = true ;
			Debug.Log(backWayPoint) ;
		}
		else
		{
			haveBackPoint = false ;
		}

		if(Physics.Raycast(transform.position,Vector3.left,out leftHit,raycastRange,layer))
		{
			Debug.Log("Hit") ;
			leftWayPoint = leftHit.transform.position ;
			haveLeftPoint = true ;
			Debug.Log(leftWayPoint) ;
		}
		else
		{
			haveLeftPoint = false ;
		}

		if(Physics.Raycast(transform.position,Vector3.right,out rightHit,raycastRange,layer))
		{
			Debug.Log("Hit") ;
			rightWayPoint = rightHit.transform.position ;
			haveRightPoint = true ;
			Debug.Log(rightWayPoint) ;
		}
		else
		{
			haveRightPoint = false ;
		}
	}
}
