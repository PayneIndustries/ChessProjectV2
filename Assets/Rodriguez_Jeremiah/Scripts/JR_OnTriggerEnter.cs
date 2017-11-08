using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JR_OnTriggerEnter : MonoBehaviour {

    public GameObject thisPawn;
    private GameObject enemyPawnCheck;
    private JR_Pawn parent;

    private void Start()
    {
       parent = thisPawn.GetComponent<JR_Pawn>();       
    }

    void OnTriggerEnter(Collider other)     
    {
        enemyPawnCheck = other.gameObject;
        parent.IsThereAPawn();
    }   

    public GameObject EnemyPawnCheck()
    {
        return enemyPawnCheck;
    }
}
