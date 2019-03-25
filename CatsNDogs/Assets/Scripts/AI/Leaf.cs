using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public virtual void StartBehaviour(Agent _agent){
        Debug.Log("No behaviour given");
    }

    public virtual void Succeed(){
        Debug.Log("No behaviour given");
    }

    public virtual void Continue(){
        Debug.Log("No behaviour given");
    }

    public virtual void Failed(){
        Debug.Log("No behaviour given");
    }
}
