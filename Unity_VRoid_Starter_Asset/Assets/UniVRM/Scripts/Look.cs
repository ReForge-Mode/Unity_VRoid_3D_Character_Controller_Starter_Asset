using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
	public GameObject target;				//reference to the Target gameobject
	public GameObject face;					//reference to the character's face
	public GameObject nearestObject;        //current nearest object
	public float smoothTime = 1;			//the smoothing timing
	public List<GameObject> objectsInSight;

	private Vector3 currentVelocity;

	private void Update()
	{
		MoveTargetLookAt();
	}

	private void OnTriggerEnter(Collider other)
	{
		//if (other.CompareTag("Wall")) return;

		if(nearestObject == null)
		{
			nearestObject = other.gameObject;
		}

		if(!objectsInSight.Contains(other.gameObject))
		{
			objectsInSight.Add(other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(objectsInSight.Contains(other.gameObject))
		{
			objectsInSight.Remove(other.gameObject);
		}

		if(other.gameObject == nearestObject)
		{
			FindNearestObject();
		}
	}

	private void MoveTargetLookAt()
	{
		if(nearestObject != null)
		{
			target.transform.position = Vector3.SmoothDamp(target.transform.position,
				nearestObject.transform.position, ref currentVelocity, smoothTime * Time.deltaTime);
		}
		else
		{
			target.transform.position = Vector3.SmoothDamp(target.transform.position,
				face.transform.position + new Vector3(0, 1.5f, 1f), ref currentVelocity, smoothTime * Time.deltaTime);
		}
	}

	//Note: Original code from the tutorial.
	//To quickly uncomment this code, select all lines in green and press Ctrl + K + U
	//To comment it again, select all and press Ctrl + K + C
	//private void FindNearestObject()
	//{
	//	if (objectsInSight.Count == 0)
	//	{
	//		nearestObject = null;
	//	}
	//	else if (objectsInSight.Count == 1)
	//	{
	//		nearestObject = objectsInSight[0];
	//	}
	//	else
	//	{
	//		nearestObject = objectsInSight[0];
	//		for (int i = 1; i < objectsInSight.Count; i++)
	//		{
	//			if (Vector3.Distance(face.transform.position, objectsInSight[i].transform.position)
	//				< Vector3.Distance(face.transform.position, nearestObject.transform.position))
	//			{
	//				nearestObject = objectsInSight[i];
	//			}
	//		}
	//	}
	//}

	//Optimized version
	private void FindNearestObject()
	{
		if(objectsInSight.Count == 0)
		{
			nearestObject = null;
		}
		else if(objectsInSight.Count == 1)
		{
			nearestObject = objectsInSight[0];
		}
		else
		{
			//This is just a variable to hold our current nearest object (caching)
			nearestObject = objectsInSight[0];
			var nearestObjectDistance = getDistance(face.transform.position, 
											nearestObject.transform.position);

			for (int i = 1; i < objectsInSight.Count; i++)
			{

				//Optimized version: We don't need to recalculate distance between
				//the current nearest object and the character's face if the current nearest object
				//is still the same object

				if (getDistance(face.transform.position, objectsInSight[i].transform.position) 
					< nearestObjectDistance)
				{
					nearestObject = objectsInSight[i];

					nearestObjectDistance = getDistance(face.transform.position,
											nearestObject.transform.position);
				}
			}
		}	
	}

	//Optimized version: We've replaced Vector3.Distance with sqrMagnitude.
	//Apparently, Vector3.Distance uses square root function which is more costly.
	//I don't quite understand that myself, so let's just follow the pros!
	private float getDistance(Vector3 a, Vector3 b)
	{
		return (a - b).sqrMagnitude;
	}
}