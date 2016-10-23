using UnityEngine;
using System.Collections;

public class ZigZag : MonoBehaviour {

	Vector3 startPosition;
	Vector3 targetPositionLeft;
	Vector3 targetPositionRight;

	bool isLeft = false;

	// the time the lerp will take
	float targetlerpTime = 10.0f;
	// the current state of the time during the lerp
	float currentLerpTime = 0.0f;

	// Use this for initialization
	void Start () 
	{
		startPosition = transform.localPosition;
		targetPositionLeft = transform.localPosition;
		targetPositionRight = transform.localPosition;
		targetPositionLeft.x = 0.2f;
		targetPositionRight.x = -0.2f;
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


		if (!isLeft)
		{
			if (transform.position != targetPositionLeft)
			{
				// use time elapsed as a percentage of the target time as speed
				float travelPercentCompleted = currentLerpTime / targetlerpTime;

				// lerp the thing
				transform.localPosition = Vector3.Lerp(startPosition, targetPositionLeft, travelPercentCompleted);
			}
			else
			{
				isLeft = true;
				startPosition = targetPositionLeft;
				currentLerpTime = 0.0f;
			}
		}
		else
		{
			if (transform.position != targetPositionRight)
			{
				// use time elapsed as a percentage of the target time as speed
				float travelPercentCompleted = currentLerpTime / targetlerpTime;

				// lerp the thing
				transform.localPosition = Vector3.Lerp(startPosition, targetPositionRight, travelPercentCompleted);
			}
			else
			{
				isLeft = false;
				startPosition = targetPositionRight;
				currentLerpTime = 0.0f;
			}
		}

	}
}
