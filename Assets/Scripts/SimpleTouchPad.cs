using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleTouchPad : MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerUpHandler
{

	private Vector2 origin;

	public void OnPointerDown(PointerEventData data)
	{
		origin = data.position;
		//Debug.Log ("Touched Screen at point: "+origin);
	}

	public void OnDrag(PointerEventData data)
	{

	}

	public void OnPointerUp(PointerEventData data)
	{
		origin = Vector2.zero;
	}

	public Vector2 GetTouchedPoint()
	{
		return origin;
	}
}
