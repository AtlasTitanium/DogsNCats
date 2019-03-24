using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRunAway : Leaf
{
    public Unit AStarUnit;
    public CatTree cat;

    private Agent agent;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
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
