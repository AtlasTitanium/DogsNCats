using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScratch : Leaf
{
    public float waitSecondsForAttack;
    private Agent agent;
    private CatTree cat;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        cat = agent.GetComponent<CatTree>();

        StartCoroutine(DoDamage());
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

    //behaviour
    IEnumerator DoDamage(){
        yield return new WaitForSeconds(waitSecondsForAttack);
        cat.seenDog.GetComponent<CatTree>().health -= Mathf.RoundToInt(cat.catDamage);
        if(cat.seenDog.GetComponent<CatTree>().health <= 0){
            Destroy(cat.seenDog);
            cat.seenDog = null;
        }
        agent.Succeed();
    }
}
