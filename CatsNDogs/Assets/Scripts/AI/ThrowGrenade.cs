using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : Leaf
{
    private Agent agent;
    
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        Debug.Log("throw grenade");
        Succeed();
    }

    public override void Succeed(){
        agent.Succeed();
        agent = null;
    }

    public override void Continue(){
        Debug.Log("No behaviour given");
    }

    public override void Failed(){
        Debug.Log("No behaviour given");
    }
}
