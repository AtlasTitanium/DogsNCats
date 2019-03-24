using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTree : Agent
{
    [Header("Dog Info")]
    public int health;
    public int dogSize;
    public float timeToWait;

    [Header("Behaviour")]
    public Leaf seeCat;
    public Leaf lowHealth;
    public Leaf seeTree;
    public Leaf nothingElse;

    //All privates
    private int initHealth;
    private Leaf currentLeaf;
    [HideInInspector]
    public GameObject seenCat;
    [HideInInspector]
    public GameObject seenTree;

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
        } else if(FindTree()){
            currentLeaf = seeTree;
        } else if(FindCat()){
            currentLeaf = seeCat;
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

    //Dog behaviour
    private bool FindCat(){
        return true;
    }
    private bool FindTree(){
        return true;
    }

}
