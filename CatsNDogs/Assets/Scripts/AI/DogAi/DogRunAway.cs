using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRunAway  : Leaf
{   
    public Transform spawn;
    private Agent agent;
    private DogTree dog;
    private Unit AStarUnit;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();
        AStarUnit = agent.GetComponent<Unit>();

        //behaviour
        AStarUnit.target = spawn;
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
