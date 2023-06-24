using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModel : MonoBehaviour{

    public GameObject obj;

    void Awake() {
        Instantiate(obj);
    }
}
