using UnityEngine;
using System.Collections;

public class moveVersion2 : MonoBehaviour {

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
			transform.position = new Vector3(slot.transform.position.x, slot.position.y, 4.9F);
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
				transform.position = new Vector3(hit.point.x, hit.point.y, 4.9F);
			}
		}
	}
}
