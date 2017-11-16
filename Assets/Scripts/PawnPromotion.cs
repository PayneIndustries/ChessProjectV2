using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPromotion : MonoBehaviour
{

//        Developer Name: Ryan Wilson
//         Contribution: 
                  //Setup the pawn promotion script and created the area that lets the pawns activate the UI
                //  element that lets the player promote the pawn to another unit.
                 // The script gets references to things in the scene so it knows where it should be working and what it should be
    //                Promote the pawns
    //                11/9/17 - 11/10/17
    //                References: No references were used
    //                        Links: NA

//        Developer Name: Jeremiah Rodriguez
//         Contribution: Fixed bugs on the pawn promotion script and really fixed the majority of the script
    //                Promote the pawns
    //                11/9/17 - 11/10/17
    //                References: No references were used
    //                        Links: NA

        //Assisted by Zaryn

    ZM_BoardManager boardRef;
    public GameObject pawn;
    public GameObject promoUI;
    public GameObject Queen;
    public GameObject Bishop;
    public GameObject Knight;
    public GameObject Rook;
    public GameObject BlackQueen;
    public GameObject BlackBishop;
    public GameObject BlackKnight;
    public GameObject BlackRook;
    public GameObject BoardManager;

    // Use this for initialization
    void Start () {
        promoUI = GameObject.Find("PromotionUI");
        promoUI.SetActive(false);
        boardRef = BoardManager.GetComponent<ZM_BoardManager>();
        print("Hello");
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Pawn")
        {
            pawn = other.gameObject;
            promoUI.SetActive(true);
        }
    }

    public void SpawnQueen()
    {
        JR_Queen Qscript;
        Qscript = Queen.GetComponent<JR_Queen>();
        Qscript.Instantiate();
        if (pawn.transform.position.z == 7)
        {
            Instantiate(Queen, new Vector3(pawn.transform.position.x, 0.5f, pawn.transform.position.z), Quaternion.identity);
            Destroy(pawn);
            
        }
        else
        {
            Instantiate(BlackQueen, new Vector3(pawn.transform.position.x, 0.5f, pawn.transform.position.z), Quaternion.identity);
            Destroy(pawn);
            boardRef.turnSwapCheck.blackPieces.Remove(pawn);
        }
        Debug.Log("Has an Object been instantiated?");
        promoUI.SetActive(false);
    }
    public void SpawnBishop()
    {
        JR_Bishop Bscript;
        Bscript = Bishop.GetComponent<JR_Bishop>();
        Bscript.Instantiate();
        if (pawn.transform.position.z == 7)
        {
            Instantiate(Bishop, new Vector3(pawn.transform.position.x, 0.1f, pawn.transform.position.z), Quaternion.identity);
            Destroy(pawn);
            boardRef.turnSwapCheck.whitePieces.Add(Bishop);
            boardRef.turnSwapCheck.whitePieces.Remove(pawn);

        }
        else
        {
            Instantiate(BlackBishop, new Vector3(pawn.transform.position.x, 0.1f, pawn.transform.position.z), Quaternion.identity);
            Destroy(pawn);
            boardRef.turnSwapCheck.blackPieces.Remove(pawn);
        }
        Debug.Log("Has an Object been instantiated?");
        promoUI.SetActive(false);
    }
    public void SpawnKnight()
    {
        JR_Knight Kscript;
        Vector3 knightPosition;
        knightPosition = pawn.transform.position;
        
        Kscript = Knight.GetComponent<JR_Knight>();
        Kscript.Instantiate();
        if (pawn.transform.position.z == 7)
        {
            Instantiate(Knight, new Vector3(pawn.transform.position.x, 0.95f, pawn.transform.position.z), Quaternion.identity);
            Destroy(pawn);
            boardRef.turnSwapCheck.whitePieces.Remove(pawn);
        }
        else
        {
            Instantiate(BlackKnight, new Vector3(pawn.transform.position.x, 0.95f, pawn.transform.position.z), Quaternion.identity);
            Destroy(pawn);
            boardRef.turnSwapCheck.blackPieces.Remove(pawn);
        }

        promoUI.SetActive(false);
    }
    public void SpawnRook()
    {
        JR_Rook Rscript;
        
        Rscript = Rook.GetComponent<JR_Rook>();
        Rscript.Instantiate();
        if (pawn.transform.position.z == 7)
        {
            Instantiate(Rook, new Vector3(pawn.transform.position.x, 0.5f, pawn.transform.position.z), Quaternion.identity);
            Destroy(pawn);
            boardRef.turnSwapCheck.whitePieces.Remove(pawn);
        }
        else
        {
            Instantiate(BlackRook, new Vector3(pawn.transform.position.x, 0.5f, pawn.transform.position.z), Quaternion.identity);
            Destroy(pawn);
            boardRef.turnSwapCheck.blackPieces.Remove(pawn);
        }
        promoUI.SetActive(false);
    }
}
