using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDamage : Leaf
{   
    public float waitSecondsForAttack;
    private Agent agent;
    private DogTree dog;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();

        //behaviour
        Debug.Log("dog does damage");
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
        dog.seenCat.GetComponent<CatTree>().health -= Mathf.RoundToInt(dog.dogDamage);
        if(dog.seenCat.GetComponent<CatTree>().health <= 0){
            Destroy(dog.seenCat);
            dog.seenCat = null;
        }
        agent.Succeed();
    }
}
