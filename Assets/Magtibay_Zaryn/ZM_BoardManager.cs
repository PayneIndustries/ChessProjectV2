﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZM_BoardManager : MonoBehaviour {

    public GameObject[,] Tiles = new GameObject [8,8];
    public GameObject[] ChessPieces = new GameObject[32];
    private GameObject selectedTile;
    private JR_TilePositionScript tileLocationscript;
    private JR_CameraTileLocation cameraControl;
    private Vector3 positionOfTileSelected;
    public Camera Camera;

    public Color brown;
    public Color lightB;

    public GameObject tile;

    private GameObject pawn;

    // Use this for initialization
    void Start () {
        
        cameraControl = Camera.GetComponent<JR_CameraTileLocation>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tiles[i, j] = Instantiate(tile, new Vector3(i, 0, j), Quaternion.identity);
                    if (i % 2 != 0 && j % 2 != 0 || i % 2 == 0 && j % 2 == 0)
                    {
                        Tiles[i, j].GetComponent<Renderer>().material.color = brown;
                    }
                    else
                    {
                        Tiles[i, j].GetComponent<Renderer>().material.color = lightB;
                    }
                }
            }
        }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            cameraControl.OnClick();

            selectedTile = cameraControl.getObject();

            SelectedTile();
        }

	}

    public GameObject whatTileIsPawnOn(GameObject pawn) {
        var x = pawn.transform.position.x;
        var z = pawn.transform.position.z;
        var gridPosition = Tiles[(int)x, (int)z];
        return gridPosition;
        //return Tiles[(int)x, (int)z];

    }


    // Accessor for Calling Gameobject after raycasthit
    public GameObject SelectedTile()
    {

        foreach (GameObject tile in Tiles)
        {
            if (tile == cameraControl.getObject())
            {
                selectedTile = tile;
            }
        }

        if (selectedTile == null)
        {
            Debug.Log("I am not a tile!");
            selectedTile = cameraControl.getObject();
        }

        else
        {
            tileLocationscript = selectedTile.GetComponent<JR_TilePositionScript>();

            if (tileLocationscript.TilePosition() != null && tileLocationscript != null)
            {
                positionOfTileSelected = tileLocationscript.TilePosition();
                PositionOfSelectedTile();
            }

            Debug.Log(selectedTile);

        }

        
            //return tile;
        //}

        return selectedTile;
    }

    public Vector3 PositionOfSelectedTile()
    {
        if (positionOfTileSelected != null)
        {
            Debug.Log(positionOfTileSelected);
        }
        return positionOfTileSelected;
        
    }
}

//Editted by Jeremiah Rodriguez


    //figure out how to tell what tile a pawn is on.
    //return tile location to get a tile out of the array