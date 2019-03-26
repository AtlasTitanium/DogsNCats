using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealpCat : Leaf
{
    public int healingLick = 20;
    private Agent agent;
    private CatTree cat;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        cat = agent.GetComponent<CatTree>();

        if(cat.heardCat != null){
            cat.heardCat.health += healingLick;
            if(cat.heardCat.health >= cat.heardCat.initHealth/10){
                cat.heardCat.askingForHealp = false;
                Succeed();
            }
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
