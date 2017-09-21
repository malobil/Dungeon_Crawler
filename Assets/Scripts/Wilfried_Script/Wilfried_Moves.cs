using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class Wilfried_Moves : MonoBehaviour {

	public float raycastRange ; // range of raycast
	public float movementSpeed ; // player's speed
	public float rotationSpeed ; // player turn speed
	public float maxHP = 100 ;
	public float currentHP ;
	public float currentAtk = 5 ;
	public Image hpBar ;

	private Vector3 frontWayPoint ; // the front direction point
	private Vector3 backWayPoint ; // the back direction point
	private Vector3 leftWayPoint ; // the left direction point
	private Vector3 rightWayPoint ; // the right direction point

	private Vector3 destination ; // player's destination

	private bool haveFrontPoint ; // check if you can go forward
	private bool haveBackPoint ; // check if you can go backward
	private bool haveLeftPoint;	// check if you can go left
	private bool haveRightPoint ;	// check if you can go right

	private float currentRotation ;
	private Quaternion qTo ;

	private bool canMove = true ;

	private bool dotIsActive = false ;

	// Use this for initialization
	void Start () 
	{
		if(currentHP > maxHP)
		{
			currentHP = maxHP ;
		}

		destination = transform.position ;
		qTo = transform.rotation ;
		currentRotation = transform.rotation.eulerAngles.y ;
		Debug.Log(currentRotation) ;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(Input.GetKeyDown("z") && haveFrontPoint && canMove)
		{
			//isMoving = true ;
			destination = frontWayPoint ;
		}

		if(Input.GetKeyDown("s") && haveBackPoint && canMove)
		{
			//isMoving = true ;
			destination = backWayPoint ;
		}

		if(Input.GetKeyDown("q") && haveLeftPoint && canMove)
		{
			//isMoving = true ;
			destination = leftWayPoint ;
		}

		if(Input.GetKeyDown("d") && haveRightPoint && canMove)
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
		//Debug//
		/*Debug.DrawRay(transform.position,Vector3.forward * raycastRange,Color.green) ;
		Debug.DrawRay(transform.position,Vector3.back * raycastRange,Color.green) ;
		Debug.DrawRay(transform.position,Vector3.left * raycastRange,Color.green) ;
		Debug.DrawRay(transform.position,Vector3.right * raycastRange,Color.green) ;*/

		// Variable that stock object hit //
		RaycastHit frontHit ;
		RaycastHit backHit ;
		RaycastHit leftHit ;
		RaycastHit rightHit ;

		//Shot a ray in 4 direction to check if got a wayPoint //

		//Check forward//
		if(Physics.Raycast(transform.position,transform.forward,out frontHit,raycastRange))
		{
			//Debug.Log(frontHit.transform.gameObject.layer) ;
			if(frontHit.transform.gameObject.layer == 8)
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
		}
		else
		{
			haveFrontPoint = false ;
		}

		//Check backward//
		if(Physics.Raycast(transform.position,-transform.forward,out backHit,raycastRange))
		{
			if(backHit.transform.gameObject.layer == 8)
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
		}
		else
		{
			haveBackPoint = false ;
		}

		//Check left//
		if(Physics.Raycast(transform.position,-transform.right,out leftHit,raycastRange))
		{
			if(leftHit.transform.gameObject.layer == 8)
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
		}
		else
		{
			haveLeftPoint = false ;
		}

		//Check right//
		if(Physics.Raycast(transform.position,transform.right,out rightHit,raycastRange))
		{
			if(rightHit.transform.gameObject.layer == 8)
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
		else
		{
			haveRightPoint = false ;
		}
	}

	//Move the player to a destination
	void Move()
	{
		if(destination != transform.position)
		{
			transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime) ;
			canMove = false ;
		}
		else
		{
			canMove = true ;
		}
	}

	//turn the camera left or right//
	void TurnCamera()
	{
		if(qTo != transform.rotation)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotationSpeed * Time.deltaTime) ; // need check to not rotate
			canMove = false ;
		}
		else if(qTo == transform.rotation) 
		{
			canMove = true ;
		}
	}

	//HP functions //
	void CheckHP()
	{
		if(currentHP <= 0)
		{
			Destroy(gameObject) ;
		}
	}

	public void AddMaxHp(float hpGain)
	{
		maxHP += hpGain ;
		ChangeHealthBar() ;
		Debug.Log(maxHP) ;
	}

	public void RetireMaxHp(float hpLost)
	{
		maxHP -= hpLost ;
		currentHP -= hpLost ;
		ChangeHealthBar() ;
	}

	void ChangeHealthBar()
	{
		hpBar.fillAmount = currentHP/maxHP ;
	}

	public void TakeInstantDamage(float damage)
	{
		currentHP -= damage ;

		if(hpBar != null)
		{
			ChangeHealthBar() ;
			Debug.Log("life") ;
		}

		CheckHP() ;
	}

	public void TakeOnTimeDamage(float damage)
	{
		if(!dotIsActive)
		{
			StartCoroutine(WaitDot(damage)) ;
			dotIsActive = true ;
		}
	}

	//Atk functions //
	public void UpAtk(float numberToAdd)
	{
		currentAtk += numberToAdd ;
		Debug.Log(currentAtk) ;
	}

	public void DownAtk(float numberToSubtract)
	{
		currentAtk -= numberToSubtract ;
		Debug.Log(currentAtk) ;
	}

	//Function return my nearest points // (mainly for AI)
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

	IEnumerator WaitDot(float damage)
	{
		TakeInstantDamage(damage) ;
		yield return new WaitForSeconds(2) ;
		dotIsActive = false ;
	}

}
