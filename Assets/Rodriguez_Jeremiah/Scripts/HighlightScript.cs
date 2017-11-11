using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*        
 *        Assisted Ryan Wilson.
//        Developer Name: Jeremiah Rodriguez
//         Contribution: Highlight Script for all pawns in the scene.
//         Feature : This script handles all the OnMouse Commands and eddited the script.
//         Start & End dates : 10/28/17 - 11/6/17
    //                References: No references were used
    //                        Links: NA


    /*
//        Developer Name: Ryan Wilson
//         Contribution:
//                Units are tagged as selected and highlighted a different color when they are clicked on.
                  If there is already a selected unit, then the currently selected one is deselected.
//                11/3/17 - 11/5/17
//                
//                                      
//*/

public class HighlightScript : MonoBehaviour
{ 
    public GameObject pawn;

    [SerializeField]
    GameObject[] SelectedPieces;
    GameObject tagSelected;

    public bool isEnabled = true;
    public Color TeamColor;
    private bool isSelected = false;
    private bool mouseIsOver;

    private void OnMouseOver()
    {
        if (isEnabled)
        {
            mouseIsOver = true;
            if (isSelected == false)
            {
                foreach (GameObject i in SelectedPieces)
                {
                    i.GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
        }

    }
    
    private void OnMouseExit()
    {
        if (isEnabled)
        {
            mouseIsOver = false;
            if (isSelected == false)
            {
                foreach (GameObject i in SelectedPieces)
                {
                    i.GetComponent<Renderer>().material.color = TeamColor;
                }
            }
        }
    }
    
    private void OnMouseDown()
    {
        if (isEnabled)
        {
            tagSelected = GameObject.FindGameObjectWithTag("Selected");
            mouseIsOver = false;
            Selected();
            SetSelected();
        }
    }

    void Update()
    {
        if(pawn.tag == "Selected")
        {
            isSelected = true;
        }
        else if (pawn.tag == "Pawn")
        {
            isSelected = false;
        }

        if(pawn.tag != "Selected" && mouseIsOver != true )
        {
            Selected();
        }

    }

    public void Selected()
    {
        foreach (GameObject i in SelectedPieces)
        {
            i.GetComponent<Renderer>().material.color = TeamColor;
        }
    
            
    }

    public void SetSelected()
    {
            if (tagSelected != null)
            {
                //tagSelected.GetComponentInChildren<Renderer>().material.color = TeamColor;
                foreach (GameObject i in SelectedPieces)
                {
                    i.GetComponent<Renderer>().material.color = TeamColor;
                }

                tagSelected.tag = "Pawn";
            }

            pawn.tag = "Selected";

            foreach (GameObject i in SelectedPieces)
            {
                i.GetComponent<Renderer>().material.color = Color.yellow;
            }

    }

    public void StopHighlight()
    {
        foreach (GameObject i in SelectedPieces)
        {
            i.GetComponent<Renderer>().material.color = TeamColor;
        }

    }

    public bool IsSelected()
    {
        return isSelected;
    }
}