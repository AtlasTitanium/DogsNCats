using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAskForHealp : Leaf
{
    public LayerMask catLayer;
    public int miauwRange;
    public Leaf runAway;
    private Agent agent;
    private CatTree cat;
    public override void StartBehaviour(Agent _agent){
        agent = _agent;
        cat = agent.GetComponent<CatTree>();

        

        //Debug.Log("asking for healp");
        if(cat.health <= cat.initHealth/10){
            cat.askingForHealp = true;
            MiauwForHealp();
            Continue();
        } else {
            cat.askingForHealp = false;
            ThankOthers();
            runAway.StartBehaviour(agent);
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

    //behaviour miauw
    private void MiauwForHealp(){
        //Debug.Log("/Play miauw sound/");
        Collider[] allOtherCats = Physics.OverlapSphere(transform.position, miauwRange, catLayer);
        if(allOtherCats.Length >= 1){
            foreach(Collider c in allOtherCats){
                if(c.gameObject == this.gameObject){
                    continue;
                }
                c.transform.GetComponent<CatTree>().heardCat = cat;
            }
        }
    }

    private void ThankOthers(){
        //Debug.Log("/Play miauw sound/");
        Collider[] allOtherCats = Physics.OverlapSphere(transform.position, miauwRange, catLayer);
        if(allOtherCats.Length >= 1){
            foreach(Collider c in allOtherCats){
                if(c.gameObject == this.gameObject){
                    continue;
                }
                c.transform.GetComponent<CatTree>().heardCat = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, miauwRange);
    }
}
