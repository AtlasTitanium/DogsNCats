using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTree : Agent
{
    [Header("Cat Info")]
    public int health;
    public float timeToWait;

    [Header("Behaviour")]
    public Leaf seeDog;
    public Leaf hearMiauw;
    public Leaf lowHealth;
    public Leaf nothingElse;

    //All privates
    private int initHealth;
    private Leaf currentLeaf;
    [HideInInspector]
    public GameObject seenDog;

    void Start(){
        initHealth = health;
        currentLeaf = nothingElse;
        StartCoroutine(Repeat());
    }

    public override IEnumerator Repeat(){
        yield return new WaitForSeconds(timeToWait);
        if(currentLeaf != null){currentLeaf.StartBehaviour(this);}
    }

    public override void Succeed(){
        Debug.Log("Behaviour returned succesfull");

        if(health <= initHealth/10){
            currentLeaf = lowHealth;
        } else if(HearMiauw()){
            currentLeaf = hearMiauw;
        } else if(SeeDog()){
            currentLeaf = seeDog;
        }
        currentLeaf = nothingElse;

        StartCoroutine(Repeat());
    }

    public override void Continue(){
        Debug.Log("Behaviour returned continue");
        StartCoroutine(Repeat());
    }

    public override void Failed(){
        Debug.Log("Behaviour returned failed");
    }

    //Cat behaviour
    private bool SeeDog(){
        return true;
    }
    private bool HearMiauw(){
        return true;
    }
}
