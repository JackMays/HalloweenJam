using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour {

	public GameObject baseTile;

	List<GameObject> wallTiles = new List<GameObject>();
	List<GameObject> floorTiles = new List<GameObject>();

	Vector2 tilePosition;

	float tileSpacing = 0.12f;
	float defaultX;

	int xBounds = 0;
	int yBounds = 0;

	int tileNo = 1;

	// Use this for initialization
	void Start () 
	{
		tilePosition = baseTile.transform.position;

		defaultX = tilePosition.x;

		Vector2 tileSize = baseTile.GetComponent<SpriteRenderer>().bounds.size;

		int cameraX =  Mathf.CeilToInt(Camera.main.aspect * Camera.main.orthographicSize / tileSize.x) * 2;
		int cameraY = Mathf.CeilToInt(Camera.main.orthographicSize / tileSize.y) * 2;

		xBounds = cameraX;
		yBounds = cameraY;

		SquareRoom();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SquareRoom()
	{
		for (int y = 0; y < yBounds; ++y)
		{
			for (int x = 0; x < xBounds; ++x)
			{	
				GameObject newTile = Instantiate(baseTile, tilePosition, Quaternion.identity) as GameObject;


				// Wall/Boundary tile
				if ((y == 0 || y == yBounds - 1) || (x == 0 || x == xBounds - 1))
				{
					// change sprite

					newTile.GetComponent<SpriteRenderer>().color = Color.white;

					newTile.AddComponent<BoxCollider2D>();
					newTile.name = "Wall Tile " + tileNo.ToString();


					wallTiles.Add(newTile);

				}
				else
				{

					// change sprite

					newTile.name = "Floor Tile " + tileNo.ToString();

					floorTiles.Add (newTile);


				}

				tilePosition.x += tileSpacing;

				++tileNo;

			}

			tilePosition.y -= tileSpacing;
			tilePosition.x = defaultX;
		}

		Destroy(baseTile);
	}
}
