using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTowardsCat : Leaf
{
    public Leaf GainDamageBonus;
    public Leaf DoDamage;

    private Agent agent;
    private Unit AStarUnit;
    private DogTree dog;

    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();
        AStarUnit = agent.GetComponent<Unit>();

        if(dog.seenCat == null){
            Failed();
            return;
        }

        AStarUnit.target = dog.seenCat.transform;
        AStarUnit.enabled = true;

        if(AStarUnit.routeFinished){
            AStarUnit.enabled = false;
            AStarUnit.target = null;
            //Debug.Log("Cat fights");
            DoDamage.StartBehaviour(agent);
        } else {
            Continue();
        }

        if(dog.seenCat.GetComponent<CatSeeDog>().currentLeaf == dog.seenCat.GetComponent<CatRunAway>()){
            //Debug.Log("Cat runs away");
            GainDamageBonus.StartBehaviour(agent);
            Succeed();
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
