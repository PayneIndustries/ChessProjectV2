using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightScript : MonoBehaviour
{ 
    public GameObject pawn;

    [SerializeField]
    GameObject[] SelectedPieces;
    GameObject tagSelected;

    public bool isEnabled = true;
    public Color TeamColor;
    private bool isSelected = false;

    private void OnMouseOver()
    {
<<<<<<< HEAD
        if (isSelected == false)
=======
        if (isEnabled)
>>>>>>> RyanBranch
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
<<<<<<< HEAD
        if (isSelected == false)
=======
        if (isEnabled)
>>>>>>> RyanBranch
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
<<<<<<< HEAD
        tagSelected = GameObject.FindGameObjectWithTag("Selected");

        if (tagSelected != null)
=======
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
>>>>>>> RyanBranch
        {
            tagSelected.GetComponentInChildren<Renderer>().material.color = TeamColor;
            tagSelected.tag = "Pawn";
        }

        pawn.tag = "Selected";

        foreach (GameObject i in SelectedPieces)
        {
            i.GetComponent<Renderer>().material.color = Color.yellow;
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
    }
}