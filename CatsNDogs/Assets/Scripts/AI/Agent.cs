using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public virtual IEnumerator Repeat(){
        Debug.Log("no agent given");
        yield return null;
    }

    public virtual void Succeed(){
        Debug.Log("no agent given");
    }

    public virtual void Continue(){
        Debug.Log("no agent given");
    }

    public virtual void Failed(){
        Debug.Log("no agent given");
    }
}
