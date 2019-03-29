using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatTree : Agent
{
    [Header("Cat Info")]
    public int health;
    public float catDamage;
    public int lookDistance;
    public float timeToWait;

    [Header("Behaviour")]
    public Leaf seeDog;
    public Leaf hearMiauw;
    public Leaf lowHealth;
    public Leaf nothingElse;

    [Header("Outside Info")]
    public LayerMask dogLayer;
    public Slider healthBar;
    
    //All privates
    [HideInInspector]
    public int initHealth;
    [HideInInspector]
    public Leaf currentLeaf;
    [HideInInspector]
    public GameObject seenDog;
    [HideInInspector]
    public bool askingForHealp = false;
    [HideInInspector]
    public CatTree heardCat;


    void Awake(){
        gameObject.layer = 9;
    }

    void Start(){
        initHealth = health;
        currentLeaf = nothingElse;
        StartCoroutine(Repeat());
    }

    void Update(){
        healthBar.value = health;
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
    public override IEnumerator Repeat(){
        yield return new WaitForSeconds(timeToWait);
        if(currentLeaf != null){currentLeaf.StartBehaviour(this);}
    }

    public override void Succeed(){
        //.Log("Behaviour returned succesfull");

        if(health <= initHealth/10){
            //Debug.Log("healthLow");
            currentLeaf = lowHealth;
        } else if(HearMiauw()){
            currentLeaf = hearMiauw;
        } else if(SeeDog()){
            currentLeaf = seeDog;
        } else {
            currentLeaf = nothingElse;
        }
    
        StartCoroutine(Repeat());
    }

    public override void Continue(){
        //Debug.Log("Behaviour returned continue");
        StartCoroutine(Repeat());
    }

    public override void Failed(){
        //Debug.Log("Behaviour returned failed");

        if(health <= initHealth/10){
            //Debug.Log("healthLow");
            currentLeaf = lowHealth;
        } else if(HearMiauw()){
            currentLeaf = hearMiauw;
        } else if(SeeDog()){
            currentLeaf = seeDog;
        } else {
            currentLeaf = nothingElse;
        }
    
        StartCoroutine(Repeat());
    }

    //Cat behaviour
    private bool SeeDog(){
        Collider[] allDogsInSight = Physics.OverlapSphere(transform.position, lookDistance, dogLayer);
        if(allDogsInSight.Length >= 1){
            foreach(Collider dog in allDogsInSight){
                if(dog.tag == "Player"){
                    seenDog = dog.gameObject;
                    return true;
                } else {
                    continue;
                }
            }
            seenDog = allDogsInSight[0].gameObject;
            return true;
        }
        return false;
    }
    
    private bool HearMiauw(){
        if(heardCat != null){
            if(heardCat.askingForHealp){
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookDistance);
    }
}
