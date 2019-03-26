using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeOnTree : Leaf
{   
    [Range(0.05f, 2.0f)]
    public float speedDecreaseTime = 0.1f;
    private float initSpeed;

    private Agent agent;
    private DogTree dog;
    private Unit AStarUnit;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();
        AStarUnit = agent.GetComponent<Unit>();

        //behaviour
        Debug.Log("pee on tree, gain speed");
        dog.speedBoostActive = true;
        dog.seenTree = null;
        initSpeed = AStarUnit.speed;
        AStarUnit.speed += AStarUnit.speed; 
        StartCoroutine(DecreaseSpeed());
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

    //behaviour
    private IEnumerator DecreaseSpeed(){
        yield return new WaitForSeconds(speedDecreaseTime);
        AStarUnit.speed -= initSpeed/20;
        if(AStarUnit.speed <= initSpeed){
            AStarUnit.speed = initSpeed;
            dog.speedBoostActive = false;
        } else {
            StartCoroutine(DecreaseSpeed());
        }
    }
}
