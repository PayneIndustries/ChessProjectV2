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
        if (mouseIsOver != true)
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
    }
}