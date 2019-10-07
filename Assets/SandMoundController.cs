using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMoundController : MonoBehaviour{

    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(active == true) {
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            transform.GetChild(2).GetComponent<ParticleSystem>().Play();
            active = false;
        }

    }
}
