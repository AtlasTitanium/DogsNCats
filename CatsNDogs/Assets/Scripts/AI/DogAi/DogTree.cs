using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogTree : Agent
{
    [Header("Dog Info")]
    public int health;
    public int dogSize;
    public float dogDamage;
    public int lookDistance;
    public float timeToWait;

    [Header("Behaviour")]
    public Leaf seeCat;
    public Leaf lowHealth;
    public Leaf seeTree;
    public Leaf nothingElse;

    [Header("Outside Info")]
    public LayerMask catLayer;
    public LayerMask treeLayer;
    public Slider healthBar;

    //All privates
    [HideInInspector]
    public int initHealth;
    [HideInInspector]
    public Leaf currentLeaf;
    [HideInInspector]
    public GameObject seenCat;
    [HideInInspector]
    public GameObject seenTree;
    [HideInInspector]
    public bool speedBoostActive = false;

    void Awake(){
        gameObject.layer = 10;
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
        //Debug.Log("Behaviour returned succesfull");
        
        if(health <= initHealth/10){
            currentLeaf = lowHealth;
        } else if(FindTree()){
            currentLeaf = seeTree;
        } else if(FindCat()){
            currentLeaf = seeCat;
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
            currentLeaf = lowHealth;
        } else if(FindTree()){
            currentLeaf = seeTree;
        } else if(FindCat()){
            currentLeaf = seeCat;
        } else {
            currentLeaf = nothingElse;
        }

        StartCoroutine(Repeat());
    }

    //Dog behaviour
    private bool FindCat(){
        Collider[] allCatsInSight = Physics.OverlapSphere(transform.position, lookDistance, catLayer);
        if(allCatsInSight.Length >= 1){
            foreach(Collider cat in allCatsInSight){
                if(cat.tag == "Player"){
                    seenCat = cat.gameObject;
                    continue;
                }
                if(cat.GetComponent<CatTree>().currentLeaf == cat.GetComponent<CatTree>().lowHealth){
                    continue;
                } else {
                    seenCat = cat.gameObject;
                }
            }
        }

        if(seenCat != null){
            return true;
        } else {
            return false;
        }
    }
    private bool FindTree(){
        if(speedBoostActive){
            return false;
        }

        Collider[] allTreesInSight = Physics.OverlapSphere(transform.position, lookDistance, treeLayer);
        if(allTreesInSight.Length >= 1){
            seenTree = allTreesInSight[0].gameObject;
            return true;
        }
        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookDistance);
    }

}
