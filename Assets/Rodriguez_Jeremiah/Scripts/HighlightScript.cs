using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightScript : MonoBehaviour
{
    public GameObject pawn;
    [SerializeField]
    GameObject[] SelectedPieces;
    public Color TeamColor;


    private void OnMouseOver()
    {
        foreach (GameObject i in SelectedPieces)
        {
            i.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        foreach (GameObject i in SelectedPieces)
        {
            i.GetComponent<Renderer>().material.color = TeamColor;
        }
    }
    //Life sucks
}