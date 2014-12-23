using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	/*
	private Vector3 screenPoint;

	private Vector3 currentPos;



	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		//Remember this sort of logic?!?!?!?!?  
		//
		//if Input.GetMouseButtonDown(0)
		//{
		//}
		// 


	}


	//Alternative loops to UPDATE method.  Remember Unity has BUILT-IN 
	//c# methods that you can re-implement!!!!

	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(transform.position);




	}

	void OnMouseDrag()
	{
		Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);

		transform.position = currentPos;
	}
	*/

	/*
	void OnCollisionEnter(Collision col)
	{
		//col.gameObject.transform.
		//Vector3 currentPos = transform.position;
		currentPos = transform.position;
		transform.position = new Vector3(Mathf.Round(currentPos.x),
		                             Mathf.Round(currentPos.y),
		                             Mathf.Round(currentPos.z));
	}
	*/


	//old drag-drop trick
	private Ray ray = new Ray();
	private RaycastHit hit = new RaycastHit();
	//if we're actually touching the object
	private bool isTouched = false;
	//nearest slot
	Transform slot;
	//slot tag's name 
	public string tagName = "Tile";
	//public string tagName = "Slot";
	
	void OnMouseDown()
	{
		isTouched = true;
	}
	
	void OnMouseUp()
	{
		isTouched = false;
		slot = findNearest();
		//if there is a slot
		if (slot != null)
		{
			//transform.position = new Vector3(slot.transform.position.x, slot.position.y, 4.9F);
			transform.position = new Vector3(slot.transform.position.x, 4.9f, slot.position.z);
		}
	}
	
	Transform findNearest()
	{
		float nearestDistanceSqr = Mathf.Infinity;
		GameObject[] taggedGameObjects = GameObject.FindGameObjectsWithTag(tagName);
		Transform nearestObj = null;
		foreach (GameObject obj in taggedGameObjects)
		{
			Vector3 objectPos = obj.transform.position;
			float distanceSqr = (objectPos - transform.position).sqrMagnitude;
			
			if (distanceSqr < nearestDistanceSqr)
			{
				nearestObj = obj.transform;
				nearestDistanceSqr = distanceSqr;
			}
		}
		
		return nearestObj;
	}
	
	void Update()
	{
		//drag/drop system
		if (isTouched)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				//transform.position = new Vector3(hit.point.x, hit.point.y, 4.9F);
				transform.position = new Vector3(hit.point.x, 4.9f, hit.point.z);
			}
		}
	}

}
