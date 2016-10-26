using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Brother : MonoBehaviour {

	public Text livesText;

	int lives = 10;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		livesText.text = "Lives: " + lives;
	}

	public void EnemyHit()
	{
		lives -= 1;
	}
}
