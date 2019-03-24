using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTowardsCat : Leaf
{
    public Unit AStarUnit;
    public DogTree dog;

    private Agent agent;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        
        AStarUnit.target = dog.seenCat.transform;
        AStarUnit.enabled = true;

        if(AStarUnit.routeFinished){
            Succeed();
        } else {
            Continue();
        }
    }

    public override void Succeed(){
        AStarUnit.enabled = false;
        agent.Succeed();
    }

    public override void Continue(){
        agent.Continue();
    }

    public override void Failed(){
        AStarUnit.enabled = false;
        agent.Failed();
    }
}
