using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSeeDog : Leaf
{
    public CatTree cat;
    public Leaf CatRunAway;
    public Leaf Scratch;
    public Leaf currentLeaf;
    public int tooBigDogSize;

    private Agent agent;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        
        if(cat.seenDog.GetComponent<DogTree>().dogSize >= tooBigDogSize){
            currentLeaf = CatRunAway;
        } else {
            currentLeaf = Scratch;
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
