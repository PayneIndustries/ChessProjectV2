using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelection : MonoBehaviour {

    private Color prevColor;
    private GameObject alreadySelected;

    [SerializeField]
    GameObject[] PieceParts;

	// Use this for initialization
	void Start () {
        prevColor = GetComponentInChildren<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {

        if(this.gameObject.transform.parent.tag == "Untagged" && GetComponentInChildren<Renderer>().material.color != prevColor)
        {
            foreach(GameObject i in PieceParts)
            {
                i.GetComponentInChildren<Renderer>().material.color = prevColor;
            }
        }
		
	}

    private void OnMouseDown()
    {
        alreadySelected = GameObject.FindGameObjectWithTag("Selected");

        if (alreadySelected != null)
        {
            alreadySelected.transform.parent.tag = "Unselected";

            this.gameObject.transform.parent.tag = "Selected";

            if (this.gameObject.transform.parent.tag == "Selected")
            {
                foreach (GameObject i in PieceParts)
                {
                    i.GetComponentInChildren<Renderer>().material.color = Color.green;
                }
            }
        }

        else
        {
            this.gameObject.transform.parent.tag = "Selected";

            if (this.gameObject.transform.parent.tag == "Selected")
            {
                foreach (GameObject i in PieceParts)
                {
                    i.GetComponentInChildren<Renderer>().material.color = Color.green;
                }
            }
        }
    }
}
