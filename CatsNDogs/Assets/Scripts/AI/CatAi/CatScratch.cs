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

        if(cat.seenDog != null){
            transform.LookAt(cat.seenDog.transform);
            StartCoroutine(DoDamage());
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

    //behaviour
    IEnumerator DoDamage(){
        yield return new WaitForSeconds(waitSecondsForAttack);
        //Debug.Log("cat Scratch");
        if(cat.seenDog != null){
            cat.seenDog.GetComponent<DogTree>().health -= Mathf.RoundToInt(cat.catDamage);
            if(cat.seenDog.GetComponent<DogTree>().health <= 0){
                Destroy(cat.seenDog);
                cat.seenDog = null;
            }
            Succeed();
        } else {
            Failed();
        }
        
    }
}
