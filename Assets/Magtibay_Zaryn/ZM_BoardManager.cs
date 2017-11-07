using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZM_BoardManager : MonoBehaviour {

<<<<<<< HEAD
     GameObject[,] Tiles = new GameObject [8,8];
=======
<<<<<<< HEAD
    [SerializeField] GameObject[] Tiles;
=======
    public GameObject[,] Tiles = new GameObject [8,8];
>>>>>>> ada16b81bed20346170aa521babb6e76ea57676d
>>>>>>> 937a197f314227b6f3f94770687612cb54a77e25
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

        if (tileLocationscript.TilePosition() != null && tileLocationscript != null)
        {
            positionOfTileSelected = tileLocationscript.TilePosition();
            positionOfSelectedTile();
        }
        return selectedTile;
    }

    public Vector3 positionOfSelectedTile()
    {
        if (positionOfTileSelected != null)
        {
            Debug.Log(positionOfTileSelected);
        }
        return positionOfTileSelected;
        
    }
}

//Editted by Jeremiah Rodriguez
