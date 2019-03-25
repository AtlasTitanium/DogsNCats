using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBonus  : Leaf
{   
    [Range(1,5)]
    public float damageIncreasePercent = 1;

    private Agent agent;
    private DogTree dog;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();

        //behaviour
        Debug.Log("dog damage increase with " + (dog.dogDamage * damageIncreasePercent) + " so the current damage is now: " + dog.dogDamage);
        dog.dogDamage += (dog.dogDamage * damageIncreasePercent);
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
