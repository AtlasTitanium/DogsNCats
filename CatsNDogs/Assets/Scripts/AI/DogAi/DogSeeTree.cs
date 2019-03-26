using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSeeTree : Leaf
{   
    public Leaf PeeOnTree;

    private Agent agent;
    private DogTree dog;
    private Unit AStarUnit;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        dog = agent.GetComponent<DogTree>();
        AStarUnit = agent.GetComponent<Unit>();

        //behaviour
        Debug.Log(Vector3.Distance(transform.position, dog.seenTree.transform.position));
        if(Vector3.Distance(transform.position, dog.seenTree.transform.position) >= 5){
            Debug.Log("going to tree");
            AStarUnit.target = dog.seenTree.transform;
            AStarUnit.enabled = true;
            Continue();
        } else {
            AStarUnit.enabled = false;
            PeeOnTree.StartBehaviour(agent);
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
