using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBonus  : Leaf
{   
    [Range(1,5)]
    public float damageIncreasePercent = 1;
    public float damageCap = 50;

    private Agent agent;
    private DogTree dog;
    private float newDamage;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();

        //behaviour
        newDamage = dog.dogDamage * damageIncreasePercent;
        Debug.Log("dog damage increase with " + (dog.dogDamage - newDamage) + " so the current damage is now: " + newDamage);
        if(newDamage >= damageCap){
            newDamage = damageCap;
        }
        
        dog.dogDamage = newDamage;
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
