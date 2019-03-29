using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSeeDog : Leaf
{
    public Leaf CatRunAway;
    public Leaf Scratch;

    [HideInInspector]
    public Leaf currentLeaf;
    public int tooBigDogSize;

    private Agent agent;
    private CatTree cat;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        cat = agent.GetComponent<CatTree>();
        
        if(cat.seenDog == null){
            Failed();
            return;
        }
        
        if(cat.seeDog.tag == "Player"){
            currentLeaf = Scratch;
        } else {
            if(cat.seenDog.GetComponent<DogTree>().dogSize >= tooBigDogSize){
                currentLeaf = CatRunAway;
            } else {
                currentLeaf = Scratch;
            }
        }
        
        if(currentLeaf != null){currentLeaf.StartBehaviour(agent);}
    }

    public override void Succeed(){
        agent.Succeed();
    }

    public override void Continue(){
        agent.Continue();
    }

    public override void Failed(){
        agent.Failed();
    }
}
