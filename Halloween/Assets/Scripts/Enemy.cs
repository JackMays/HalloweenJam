using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Score scoreboard;
	SpeedManager speed;

	GameObject player;

	Vector3 startPosition;
	Vector3 brotherPosition;
	Vector3 playerPosition = Vector3.zero;

	float brotherLerp = 0.0f;
	float vacuumLerp = 0.0f;

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
		speed = GameObject.FindGameObjectWithTag("Speed").GetComponent<SpeedManager>();

		player = GameObject.FindGameObjectWithTag("Player");

		brotherLerp = speed.GetBrotherLerp();
		vacuumLerp = speed.GetVacuumLerp();

		targetlerpTime = brotherLerp;

		startPosition = transform.position;
		brotherPosition = GameObject.FindGameObjectWithTag("Brother").transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (brotherLerp != speed.GetBrotherLerp())
		{
			brotherLerp = speed.GetBrotherLerp();
			ResetLerp(brotherLerp);

		}

		if (vacuumLerp != speed.GetVacuumLerp())
		{
			vacuumLerp = speed.GetVacuumLerp();
			ResetLerp(vacuumLerp);

		}

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

	void ResetLerp(float lerp)
	{
		targetlerpTime = lerp;
		currentLerpTime = 0.0f;
		startPosition = transform.position;
	}

	void OnTriggerEnter2D(Collider2D coll)
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
					ResetLerp(vacuumLerp);
				}
			}
			else
			{
				if (isVacuum)
				{
					Debug.Log("vacuum off");
					isVacuum = false;
					ResetLerp(brotherLerp);
				}
			}
		}

		// extra check on stay if something goes wrong in enter

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

	void OnTriggerExit2D(Collider2D coll)
	{

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
