using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAround : Leaf
{   
    private Agent agent;
    private Unit AStarUnit;

    private GameObject placeholder;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        AStarUnit = agent.GetComponent<Unit>();

        //behaviour
        if(placeholder == null){
            placeholder = new GameObject("location");
            placeholder.transform.parent = transform;
        }
        Vector3 randomLocation = new Vector3(Random.Range(transform.position.x - 20, transform.position.x + 20), transform.position.y, Random.Range(transform.position.z - 10, transform.position.z + 10));
        placeholder.transform.position = randomLocation;

        if(Vector3.Distance(transform.position, randomLocation) >= 5){
            AStarUnit.target = placeholder.transform;
            AStarUnit.enabled = true;
            Continue();
        } else {
            AStarUnit.enabled = false;
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
