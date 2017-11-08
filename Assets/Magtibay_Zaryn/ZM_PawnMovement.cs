using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZM_PawnMovement : MonoBehaviour {
    private bool isFirstMove;

    private ZM_BoardManager boardManager;

	// Use this for initialization
	void Start () {
        isFirstMove = true;
        boardManager = GetComponent<ZM_BoardManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void move() {
        if (gameObject.tag == "Selected") {
            var tile = boardManager.whatTileIsPawnOn(gameObject);
        }
    }
}
