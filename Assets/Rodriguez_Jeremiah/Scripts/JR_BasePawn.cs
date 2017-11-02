using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_BasePawn : MonoBehaviour
{

    public GameObject Controller;
    public GameObject currentPawn;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    private GameObject targetedSquare;

    // Use this for initialization
    void Start()
    {

        currentPosition = currentPawn.transform.position;
        newPosition = currentPosition;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PositionToMove()
    {
        newPosition = new Vector3(targetedSquare.transform.position.x, targetedSquare.transform.position.y + 1, targetedSquare.transform.position.z);
    }

    void MovedPosition()
    {
        if (currentPosition != newPosition)
        {
            currentPosition = newPosition;
        }
    }

    public Vector3 GetLocationOfPawn()
    {
        return currentPosition;
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
    
}