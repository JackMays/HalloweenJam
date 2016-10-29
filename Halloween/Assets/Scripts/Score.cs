using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	Text scoreText;

	int currentScore = 0;



	// Use this for initialization
	void Start () 
	{
		scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoreText.text = "Score: " + currentScore;
	}

	public void AddScore(int score)
	{
		currentScore += score;
	}

	public string GetScore()
	{
		return currentScore.ToString();
	}
}
