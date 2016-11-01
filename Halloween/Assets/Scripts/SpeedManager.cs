using UnityEngine;
using System.Collections;

public class SpeedManager : MonoBehaviour {

	int playerForceMultiplier = 1800;
	float enemyBrotherLerp = 10.0f;
	float enemyVacuumLerp = 1.0f;

	float speedIncrement = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpeedUp()
	{
		playerForceMultiplier *= (int)speedIncrement;
		enemyBrotherLerp /= speedIncrement;
		enemyVacuumLerp /= speedIncrement;
	}

	public int GetForceMultiplier()
	{
		return playerForceMultiplier;
	}

	public float GetBrotherLerp()
	{
		return enemyBrotherLerp;
	}

	public float GetVacuumLerp()
	{
		return enemyVacuumLerp;
	}
}
