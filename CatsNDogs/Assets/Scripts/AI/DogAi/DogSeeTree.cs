using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSeeTree : Leaf
{   
    public Leaf PeeOnTree;

    private Agent agent;
    private DogTree dog;
    private Unit AStarUnit;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();
        AStarUnit = agent.GetComponent<Unit>();

        //behaviour
        if(dog.health <= dog.initHealth/10){
            AStarUnit.target = dog.seenTree.transform;
            AStarUnit.enabled = true;

            if(AStarUnit.routeFinished){
                PeeOnTree.StartBehaviour(agent);
            } else {
                Continue();
            }
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
