using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_BasePawn : MonoBehaviour
{
    /*        
//        Developer Name: Jeremiah Rodriguez
//         Contribution: Created the BasePawn to build off of every other pawn.
//         Feature : Created to run the base movement of the pieces. This script handles Highlight.
//         Start & End dates : 10/28/17 - 11/10/17
    //                References: No references were used
    //                        Links: NA

//              
//                        
//*/

    public GameObject Controller;
    public GameObject currentPawn;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    private GameObject targetedSquare;
    private JR_TilePositionScript movementCheck;
    public JR_BasePawn thisPawnScript;

    [SerializeField]public Vector3 startPosition;
    private ZM_BoardManager board;
    public GameObject BoardManager;
    public bool isWhite;
    protected TurnSwap turnSwap;
    private HighlightScript setColor;
    public bool inCheck;

    // Use this for initialization

    public void Awake()
    {
       turnSwap = Controller.GetComponent<TurnSwap>(); 
    }
    public void Start()
    {
        if (turnSwap.wasInstantiated != true)
        {
            currentPawn.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        }
        currentPosition = currentPawn.transform.position;
        newPosition = currentPosition;
        board = BoardManager.GetComponent<ZM_BoardManager>();
        turnSwap = Controller.GetComponent<TurnSwap>();
        setColor = currentPawn.GetComponent<HighlightScript>();
        thisPawnScript = this.GetComponent<JR_BasePawn>();

        if (isWhite)
        {
            setColor.TeamColor = Color.white;
        }
        else
        {
            setColor.TeamColor = Color.black;
        }
    }

    public void Update()
    {

    }
    
    public void FixedUpdate() {

    }

    public void PositionToMove()
    {
        if (inCheck)
        {
            print("You are in check!, You must move your king!!!");
        }
        else
        {
            if (currentPawn.tag == "Selected")
            {
                if (board.SelectedTile() != null && board.SelectedTile().tag != "Occupied")
                {
                    targetedSquare = board.SelectedTile();
                    newPosition = new Vector3(targetedSquare.transform.position.x, currentPawn.transform.position.y, targetedSquare.transform.position.z);
                    MovedPosition();

                }

                else if (board.SelectedTile() == null)
                {
                    Debug.Log("Object instance 'board' not set");
                }
            }
        }
    }

    public void MovedPosition()
    {
        if (currentPosition != newPosition)
        {
            currentPosition = newPosition;

            currentPawn.transform.position = newPosition;

            targetedSquare = null;

            turnSwap.curPlayerWhite = !turnSwap.curPlayerWhite;

            turnSwap.SwapTurn();

            board.SelectedTileToNull();
            
        }
    }

    public Vector3 GetLocationOfPawn()
    {
        return currentPosition;
    }

    public GameObject Board()
    {
        return BoardManager;
    }

   /* protected void movementUnhiglight()
    {
        foreach (GameObject tile in board.Tiles)
        {
            if (tile.transform.position.z % 2 != 0 && tile.transform.position.x % 2 != 0 || tile.transform.position.z % 2 == 0 && tile.transform.position.x % 2 == 0)
            {
                tile.GetComponent<Renderer>().material.color = board.brown;
            }
            else
            {
                tile.GetComponent<Renderer>().material.color = board.lightB;
            }
        }
    }*/

    private void OnDestroy()
    {
        if (isWhite)
        {
            //remove from white array
            turnSwap.whitePieces.Remove(currentPawn);
        } else
        {
            //remove from black array
            turnSwap.blackPieces.Remove(currentPawn);
        }
    }

    public void Instantiate()
    {
        Controller = GameObject.Find("ControlManagerScript");
        BoardManager = GameObject.Find("BoardControl");
    }
}
    //Edited by Zaryn Magtibay