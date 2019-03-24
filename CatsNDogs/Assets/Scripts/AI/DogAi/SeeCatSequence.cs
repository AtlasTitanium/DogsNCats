using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeCatSequence : Leaf
{
    public DogTree dog;
    public Leaf RunTowardsCat;
    public Leaf GainDamageBonus;
    public Leaf DoDamage;
    public Leaf CatRunAwayLeaf;
    

    private Agent agent;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        RunTowardsCat.StartBehaviour(agent);

        if(dog.seenCat.GetComponent<CatSeeDog>().currentLeaf == CatRunAwayLeaf){
            GainDamageBonus.StartBehaviour(agent);
        } else {
            DoDamage.StartBehaviour(agent);
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
