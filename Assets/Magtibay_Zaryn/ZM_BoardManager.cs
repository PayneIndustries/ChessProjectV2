using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZM_BoardManager : MonoBehaviour {

    //         Developer Name: Jeremiah Rodriguez
    //         Contribution: I wrote the start of ZM_Boardmanager and continued to work with Zaryn into completing the script.
    //         Feature : This script manages everything on the board and has a major role in the entire game. This holds all the tiles and stores them as well as sends information to other scripts as to what info is on the tiles.
    //         Start & End dates : 10/28/17 - 11/10/17 
    //                References: No references were used
    //                        Links: NA

    public GameObject[,] Tiles = new GameObject [8,8];
    public GameObject[] ChessPieces = new GameObject[32];
    private GameObject selectedTile;
    private JR_TilePositionScript tileLocationscript;
    private JR_CameraTileLocation cameraControl;
    private Vector3 positionOfTileSelected;
    public Camera Camera;
    private Vector3 playerLocation;
    public TurnSwap turnSwapCheck;
    public GameObject TurnSwapHolder;

    public Color brown;
    public Color lightB;

    public GameObject tile;

    private GameObject pawn;
    private GameObject whoisthereinfo;
    private bool playerDestroyBlack;
    private bool justForKing;


    // Use this for initialization
    void Start ()
    {
        TurnSwapHolder = GameObject.Find("ControlManagerScript");
        turnSwapCheck = TurnSwapHolder.GetComponent<TurnSwap>();
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

 
	
	// Update is called once per frame.
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
        }       
        return selectedTile;
    }

    public Vector3 PositionOfSelectedTile()
    {
        if (positionOfTileSelected != null)
        {
        }
        return positionOfTileSelected;
        
    }

    public GameObject WHOISTHERE()
    {
        whoisthereinfo = tileLocationscript.WhoIsHere();
        if (whoisthereinfo != null)
        {
            JR_BasePawn blackCheck = whoisthereinfo.GetComponent<JR_BasePawn>();
            if (blackCheck.isWhite == true)
            {
                BlackCheckSetTrue();
            }
        }
        return whoisthereinfo;
    }

    public bool WhoIsThere2()
    {
        GameObject info = WHOISTHERE();
        JR_BasePawn pawn = info.GetComponent<JR_BasePawn>();


        return pawn.isWhite;

    }

    public void SelectedTileToNull()
    {
        selectedTile = null;
    }

    public bool BlackCheckSetTrue()
    {
        playerDestroyBlack = true;
        return playerDestroyBlack;
    }

    public void BlackCheckSetFalse()
    {
        playerDestroyBlack = false;
    }

    public bool JustForKing(){
        GameObject info = WHOISTHERE();
        JR_BasePawn pawn = info.GetComponent<JR_BasePawn>();
        if(pawn.isWhite == true)
        {
            justForKing = true;
        }

        return justForKing;
    }

    public bool JustForKingFalse()
    {
        justForKing = false;
        return justForKing;
    }
        
}

//Editted by Jeremiah Rodriguez


    //figure out how to tell what tile a pawn is on.
    //return tile location to get a tile out of the array