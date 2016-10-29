using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	DeathManager death;

	Text gameOverText;

	// Use this for initialization
	void Start () 
	{
		death = GameObject.FindGameObjectWithTag("Death").GetComponent<DeathManager>();

		gameOverText = GetComponent<Text>();

		gameOverText.text = gameOverText.text.Replace("<Score>", death.GetEndScore());
		gameOverText.text = gameOverText.text.Replace("<Time>", death.GetEndTime());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
