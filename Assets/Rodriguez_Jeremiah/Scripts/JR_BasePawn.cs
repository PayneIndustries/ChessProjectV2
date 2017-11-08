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

    // Use this for initialization
    public void Start()
    {
        currentPawn.transform.position = new Vector3 (startPosition.x,startPosition.y,startPosition.z);
        currentPosition = currentPawn.transform.position;
        newPosition = currentPosition;
        board = BoardManager.GetComponent<ZM_BoardManager>();

    }

    public void Update()
    {
        
    }

    public void PositionToMove()
    {
        if (currentPawn.tag == "Selected")
        {
            if (board.SelectedTile() != null && board.SelectedTile().tag != "Occupied")
            {
                targetedSquare = board.SelectedTile();
                newPosition = new Vector3(targetedSquare.transform.position.x, targetedSquare.transform.position.y + 0.5f, targetedSquare.transform.position.z);
                MovedPosition();
            }

            else if(board.SelectedTile() == null)
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