using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int forceMultiplier;

	Rigidbody2D rBody;


	// Use this for initialization
	void Start () 
	{
		rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	// for physics stuff, set interval updating
	void FixedUpdate()
	{
		// horizontal axis affected by A/D and vertical axis affected by W/S
		// Moves the rigidbodied player by physics
		rBody.AddForce(new Vector2(Input.GetAxis("Horizontal") * forceMultiplier * Time.deltaTime,
			Input.GetAxis("Vertical") * forceMultiplier * Time.deltaTime));
	}
}
