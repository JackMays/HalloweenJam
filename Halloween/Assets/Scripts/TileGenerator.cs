﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour {

	public GameObject baseTile;

	GameObject spawner;

	List<GameObject> wallTiles = new List<GameObject>();
	List<GameObject> floorTiles = new List<GameObject>();
	List<GameObject> spawnTiles = new List<GameObject>();

	Vector2 tilePosition;

	float tileSpacing = 0.12f;
	float defaultX;

	int xBounds = 0;
	int yBounds = 0;

	int tileNo = 1;

	int spawnNo = 4;

	// Use this for initialization
	void Start () 
	{
		spawner = Resources.Load("Prefabs/Spawner") as GameObject;

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

		AddSpawners();
	}

	void AddSpawners()
	{
		int currentSpawnCount = 1;

		List<GameObject> tempWallTiles = new List<GameObject>();

		for (int i = 0; i < wallTiles.Count; ++i)
		{
			tempWallTiles.Add(wallTiles[i]);
		}

		while (currentSpawnCount <= spawnNo)
		{
			int randWall = Random.Range(0, tempWallTiles.Count);
			GameObject wall = tempWallTiles[randWall];

			GameObject spawnPrefab = Instantiate(spawner, wall.transform.position, Quaternion.identity) as GameObject;

			spawnPrefab.name = "Spawner " + currentSpawnCount;

			tempWallTiles.RemoveAt(randWall);

			++currentSpawnCount;
		}
	}
}
