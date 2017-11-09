using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_BasePawn : MonoBehaviour
{

    public GameObject Controller;
    public GameObject currentPawn;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    private GameObject targetedSquare;
    private JR_TilePositionScript movementCheck;

    [SerializeField]public Vector3 startPosition;
    private ZM_BoardManager board;
    public GameObject BoardManager;
    public bool isWhite;
    private TurnSwap turnSwap;
    private HighlightScript setColor;

    // Use this for initialization
    public void Start()
    {
        currentPawn.transform.position = new Vector3 (startPosition.x,startPosition.y,startPosition.z);
        currentPosition = currentPawn.transform.position;
        newPosition = currentPosition;
        board = BoardManager.GetComponent<ZM_BoardManager>();
        turnSwap = Controller.GetComponent<TurnSwap>();
        setColor = currentPawn.GetComponent<HighlightScript>();

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
        if (currentPawn.tag == "Selected")
        {
            if (board.SelectedTile() != null && board.SelectedTile().tag != "Occupied")
            {
                targetedSquare = board.SelectedTile();
                newPosition = new Vector3(targetedSquare.transform.position.x,0.5f, targetedSquare.transform.position.z);
                MovedPosition();
                
            }
            
            else if (board.SelectedTile() == null)
            {
                Debug.Log("Object instance 'board' not set");
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

    protected void movementUnhiglight()
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
    }

    private void OnDestroy()
    {
        if (isWhite)
        {
            //remove from white array
            FindObjectOfType<TurnSwap>().whitePieces.Remove(this.gameObject);
        } else
        {
            //remove from black array
            FindObjectOfType<TurnSwap>().blackPieces.Remove(this.gameObject);
        }
    }

}

/*        
//        Developer Name: Jeremiah Rodriguez
//         Contribution: Created the BasePawn to build off of every other pawn.
//                Feature : Created to run the base movement of the pieces.
//                Start & End dates : 10/28/17 - 10/29/17
//                References:
//                        Links:
//*/


    //Edited by Zaryn Magtibay