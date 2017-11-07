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

    // Use this for initialization
    void Start()
    {
        currentPawn.transform.position = new Vector3 (startPosition.x,0.5f,startPosition.z);
        currentPosition = currentPawn.transform.position;
        newPosition = currentPosition;
        board = BoardManager.GetComponent<ZM_BoardManager>();

    }

    private void Update()
    {
        //Test Movement by removing Comments on Update.
        //if (Input.GetButtonDown("Fire1"))
        //{
           // PositionToMove();
      //  }

        
    }

    public void PositionToMove()
    {
        if (currentPawn.tag == "Selected")
        {
            if (board.selectedTile != null)
            {
                targetedSquare = board.SelectedTile();
                newPosition = new Vector3(targetedSquare.transform.position.x, targetedSquare.transform.position.y + 1, targetedSquare.transform.position.z);
                MovedPosition();
            }

            else if(board.selectedTile == null)
            {
                Debug.Log("Why am I invalid?");
            }
        }
    }

    void MovedPosition()
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

    public void OnDestroy()
    {
        Destroy(gameObject);
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