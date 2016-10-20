using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Vector3 startPosition;
	Vector3 targetPosition;

	// the time the lerp will take
	float targetlerpTime = 10.0f;
	// the current state of the time during the lerp
	float currentLerpTime = 0.0f;

	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position;
		targetPosition = GameObject.FindGameObjectWithTag("Brother").transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// add to the current time in the lerp
		currentLerpTime += Time.deltaTime;

		// make sure the current time stays within the designated time
		if (currentLerpTime > targetlerpTime)
		{
			currentLerpTime = targetlerpTime;
		}

		if (transform.position != targetPosition)
		{
			// use time elapsed as a percentage of the target time as speed
			float travelPercentCompleted = currentLerpTime / targetlerpTime;

			// lerp the thing
			transform.position = Vector3.Lerp(startPosition, targetPosition, travelPercentCompleted);
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("Brother"))
		{
			Destroy(gameObject);
		}
	}


}
