using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_CameraTileLocation : MonoBehaviour {

    //         Developer Name: Jeremiah Rodriguez
    //         Contribution: I wrote the script. It handles the camera.
    //         Feature : This is specifically made to manage the mouse via raycast and gets the position of the tile selected.
    //         Start & End dates : 10/28/17 - 11/07/17
    //                References: No references were used
    //                        Links: NA


    private GameObject tileCurrent;

    public GameObject getObject()
    {
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo)) 
        {
            
            tileCurrent = hitInfo.collider.gameObject;
        }
        return tileCurrent;
    }

    public void OnClick() { 

            getObject();
    }
    
}
