using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCat : MonoBehaviour
{
    [Header("Cat stats")]
    public int health;
    public int clawDamage;
    public int lickHeal;
    public float interactDistance;

    [Header("Referce Objects")]
    public GameObject tounge;
    public GameObject claw;

    private Animator clawAnimator;
    private Animator toungeAnimator;
    private List<GameObject> ObjectsInSight = new List<GameObject>();

    void Start(){
        clawAnimator = claw.GetComponent<Animator>();
        toungeAnimator = tounge.GetComponent<Animator>();
    }

    void Update(){
        Collider[] collidersInSight = Physics.OverlapSphere(transform.position, interactDistance);
        List<Collider> collidersList = new List<Collider>(collidersInSight);
        foreach(Collider c in collidersInSight){
            if(c.gameObject != this.gameObject && c.gameObject.tag != "Player" && c.gameObject.tag != "Enviroment" && c.gameObject.GetComponent<MeshRenderer>())
            {
                if(c.gameObject.GetComponent<MeshRenderer>().isVisible){
                    if(ObjectsInSight.Contains(c.gameObject)){
                        continue;
                    }
                    Debug.Log(c.gameObject);
                    ObjectsInSight.Add(c.gameObject);
                }
            }
        }
        if(ObjectsInSight.Count >= 1){
            for(int i = 0; i < ObjectsInSight.Count; i++){
                Debug.Log(i);
                if(ObjectsInSight[i] == null){
                    ObjectsInSight.Remove(ObjectsInSight[i]);
                } else {
                    if(ObjectsInSight[i].GetComponent<MeshRenderer>().isVisible == false){
                        ObjectsInSight.Remove(ObjectsInSight[i]);
                    } else {
                        if(!collidersList.Contains(ObjectsInSight[i].GetComponent<Collider>())){
                            ObjectsInSight.Remove(ObjectsInSight[i]);
                        }
                    }
                }
            }
        }
        

        

        if(Input.GetAxis("Fire1") >= 1){
            Debug.Log("Claw");
            clawAnimator.SetBool("Hit", true);
            if(ObjectsInSight.Count >= 1){
                foreach(GameObject g in ObjectsInSight){
                    if(g.GetComponent<DogTree>()){
                        g.GetComponent<DogTree>().health -= clawDamage;
                    } else {
                        Debug.Log("no doggers");
                    }
                }
            }
        } else {
            if(clawAnimator.GetBool("Hit")){
                clawAnimator.SetBool("Hit", false);
            }
        }

        if(Input.GetAxis("Fire2") >= 1){
            Debug.Log("Lick");
            toungeAnimator.SetBool("Lick", true);
            if(ObjectsInSight.Count >= 1){
                foreach(GameObject g in ObjectsInSight){
                    if(g.GetComponent<CatTree>()){
                        Debug.Log(g);
                        g.GetComponent<CatTree>().health += lickHeal;
                    }
                }
            }
        } else {
            if(toungeAnimator.GetBool("Lick")){
                toungeAnimator.SetBool("Lick", false);
            }
        }

        
    }
}

// ObjectsInSightArray = Resources.FindObjectsOfTypeAll<GameObject>();
// ObjectsInSight = new List<GameObject>(ObjectsInSightArray);

// List<GameObject> ObjectsInSightCopy = new List<GameObject>();
// for(int i = 0; i < ObjectsInSight.Count; i++){
//     if(ObjectsInSight[i] == this.gameObject 
//             || ObjectsInSight[i].tag == "Player" 
//                 || ObjectsInSight[i].tag == "Enviroment")
//     {
//         ObjectsInSight.Remove(ObjectsInSight[i]);
//         i--;
//     } else {
//         if(Vector3.Distance(transform.position, ObjectsInSight[i].transform.position) >= interactDistance){
//             Debug.Log(ObjectsInSight[i]);
//             if(!ObjectsInSight[i].GetComponent<MeshRenderer>()){
//                 ObjectsInSight.Remove(ObjectsInSight[i]);
//                 i--;
//             } else {
//                 if(!ObjectsInSight[i].GetComponent<MeshRenderer>().isVisible){
//                     ObjectsInSight.Remove(ObjectsInSight[i]);
//                     i--;
//                 }
//             }
//         }
//     }
// }
