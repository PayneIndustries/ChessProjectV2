using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_CameraTileLocation : MonoBehaviour {

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
