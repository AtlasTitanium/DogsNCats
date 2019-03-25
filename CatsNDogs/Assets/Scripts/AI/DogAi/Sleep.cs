using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : Leaf
{
    private Agent agent;
    private DogTree dog;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();

        Debug.Log("sleepy doggo");
        agent.Succeed();
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
