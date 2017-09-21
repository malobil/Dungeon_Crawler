using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler{
	public static GameObject itemBeingDragged ;


	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	  {
	  //	itemBeingDragged = gameObject ;
	  //	startPosition = transform.position ;
	  }

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	  {
	  	throw new System.NotImplementedException () ;
	  }

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	  {
	  	itemBeingDragged = null ;
	  }

	#endregion
}
