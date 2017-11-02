using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZM_BoardManager : MonoBehaviour {

    [SerializeField] GameObject[] Tiles;
    private GameObject selectedTile;
    private JR_TilePositionScript tileLocationscript;
    private JR_CameraTileLocation cameraControl;
    private Vector3 positionOfTileSelected;
    public Camera Camera;


    // Use this for initialization
    void Start () {
        
        cameraControl = Camera.GetComponent<JR_CameraTileLocation>();
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


    // Accessor for Calling Gameobject after raycasthit
    public GameObject SelectedTile()
    {
        tileLocationscript = selectedTile.GetComponent<JR_TilePositionScript>();
        positionOfTileSelected = tileLocationscript.TilePosition();
        positionOfSelectedTile();
        return selectedTile;
    }

    public Vector3 positionOfSelectedTile()
    {
        Debug.Log(positionOfTileSelected);
        return positionOfTileSelected;
        
    }
}

//Editted by Jeremiah Rodriguez
