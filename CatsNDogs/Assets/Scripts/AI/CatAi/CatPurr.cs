using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPurr : Leaf
{
    private Agent agent;
    private CatTree cat;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        cat = agent.GetComponent<CatTree>();

        Debug.Log("purrrrr");
        Succeed();
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
