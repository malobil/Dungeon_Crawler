using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler{
	public static GameObject itemBeingDragged ;
	public GameObject parentDAD ;
	Vector3 startPosition ;
	Vector3 resetPosition ;
	Transform startParent ;

	void OnStart ()
	{
		transform.position = resetPosition ;
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	  {

	  	itemBeingDragged = gameObject ;
	  	startPosition = transform.position ;
	  	startParent = transform.parent ;
	  	GetComponent<CanvasGroup>().blocksRaycasts = false ;
	  }

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	  {	  	
	  	transform.position = Input.mousePosition ;
	  }

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	  {
	  	itemBeingDragged = null ;
	  	GetComponent<CanvasGroup>().blocksRaycasts = true ;
	  	if(transform.parent == startParent)
	  		{
	  		transform.position = startPosition ;
	    	}
	  }

	#endregion
}
