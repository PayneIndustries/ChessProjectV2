using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightScript : MonoBehaviour
{ 
    public GameObject pawn;

    [SerializeField]
    GameObject[] SelectedPieces;
    GameObject tagSelected;

    public Color TeamColor;
    private bool isSelected = false;

    private void OnMouseOver()
    {
        if (isSelected == false)
        {
            foreach (GameObject i in SelectedPieces)
            {
                i.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }

    }
    
    private void OnMouseExit()
    {
        if (isSelected == false)
        {
            foreach (GameObject i in SelectedPieces)
            {
                i.GetComponent<Renderer>().material.color = TeamColor;
            }
        }
    }
    
    private void OnMouseDown()
    {
        tagSelected = GameObject.FindGameObjectWithTag("Selected");

        if (tagSelected != null)
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