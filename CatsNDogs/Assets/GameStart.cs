using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject catPrefab;
    public GameObject dogPrefab;
    public Button Cat;
    public Button Dog;

    void Start(){
        Cat.onClick.AddListener(IfCat);
        Cat.onClick.AddListener(IfDog);
    }

    public void IfCat(){
        Instantiate(catPrefab, Vector3.zero, Quaternion.identity);
        this.gameObject.SetActive(false);
    }
    public void IfDog(){
        Instantiate(dogPrefab, Vector3.zero, Quaternion.identity);
        this.gameObject.SetActive(false);
    }
}
