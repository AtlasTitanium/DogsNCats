using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeOnTree : Leaf
{   
    private Agent agent;
    private DogTree dog;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();

        //behaviour
        Debug.Log("pee on tree, gain health");
        dog.health += dog.initHealth / 2;
        if(dog.health >= dog.initHealth/10){
            Succeed();
        } else {
            Failed();
        }
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
