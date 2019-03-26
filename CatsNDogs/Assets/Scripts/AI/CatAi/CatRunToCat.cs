using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRunToCat : Leaf
{
    public Leaf catHealpCat;
    
    private Agent agent;
    private CatTree cat;
    private Unit AStarUnit;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        cat = agent.GetComponent<CatTree>();
        AStarUnit = agent.GetComponent<Unit>();

        if(cat.heardCat != null){
            if(Vector3.Distance(transform.position, cat.heardCat.transform.position) >= 3){
                AStarUnit.target = cat.heardCat.transform;
                AStarUnit.enabled = true;
                Continue();
            } else {
                transform.LookAt(cat.heardCat.transform);
                AStarUnit.enabled = false;
                AStarUnit.target = null;
                catHealpCat.StartBehaviour(agent);
            }
        } else {
            Failed();
            return;
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