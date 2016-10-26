using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Score scoreboard;

	GameObject player;

	Vector3 startPosition;
	Vector3 brotherPosition;
	Vector3 playerPosition = Vector3.zero;

	float brotherLerp = 10.0f;
	float vacuumLerp = 2.0f;

	// the time the lerp will take
	float targetlerpTime = 0.0f;
	// the current state of the time during the lerp
	float currentLerpTime = 0.0f;

	int killScore = 200;



	bool isVacuum = false;

	// Use this for initialization
	void Start () 
	{
		scoreboard = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
		player = GameObject.FindGameObjectWithTag("Player");

		targetlerpTime = brotherLerp;

		startPosition = transform.position;
		brotherPosition = GameObject.FindGameObjectWithTag("Brother").transform.position;
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

		if (!isVacuum)
		{

			if (transform.position != brotherPosition)
			{
				// use time elapsed as a percentage of the target time as speed
				float travelPercentCompleted = currentLerpTime / targetlerpTime;

				// lerp the thing
				transform.position = Vector3.Lerp(startPosition, brotherPosition, travelPercentCompleted);
			}
		}
		else
		{
			playerPosition = player.transform.position;

			if (transform.position != playerPosition)
			{
				// use time elapsed as a percentage of the target time as speed
				float travelPercentCompleted = currentLerpTime / targetlerpTime;

				// lerp the thing
				transform.position = Vector3.Lerp(startPosition, playerPosition, travelPercentCompleted);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("Brother") || (coll.gameObject.CompareTag("Player") && isVacuum))
		{
			Destroy(gameObject);

			if (coll.gameObject.CompareTag("Brother"))
			{
				coll.gameObject.GetComponent<Brother>().EnemyHit();
			}
			else if (coll.gameObject.CompareTag("Player") && isVacuum)
			{
				scoreboard.AddScore(killScore);
			}
		}


	}

	/*void OnCollisionExit2D(Collision2D coll)
	{


	}*/

	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.CompareTag("Vacuum"))
		{

			if (coll.gameObject.GetComponent<Vacuum>().HasVacuumActivated())
			{
				if (!isVacuum)
				{
					Debug.Log("vacuum hit");
					isVacuum = true;
					targetlerpTime = vacuumLerp;
					currentLerpTime = 0.0f;
					startPosition = transform.position;
				}
			}
			else
			{
				if (isVacuum)
				{
					Debug.Log("vacuum off");
					isVacuum = false;
					targetlerpTime = brotherLerp;
					currentLerpTime = 0.0f;
					startPosition = transform.position;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		Debug.Log(coll.gameObject.tag);

		if (coll.gameObject.CompareTag("Vacuum"))
		{
			if (isVacuum)
			{
				Debug.Log("vacuum off");
				isVacuum = false;
				targetlerpTime = brotherLerp;
				currentLerpTime = 0.0f;
				startPosition = transform.position;
			}
		}
	}


}
