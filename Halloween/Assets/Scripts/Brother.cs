using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Brother : MonoBehaviour {

	public Text livesText;

	int lives = 10;

	DeathManager death;

	// Use this for initialization
	void Start () 
	{
		death = GameObject.FindGameObjectWithTag("Death").GetComponent<DeathManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		livesText.text = "Lives: " + lives;
	}

	public void EnemyHit()
	{
		lives -= 1;

		if (lives <= 0)
		{
			death.BrotherHasDied();
		}
	}
}
