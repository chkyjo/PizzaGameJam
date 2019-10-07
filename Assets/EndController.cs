using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour {

    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null) {
            winPanel.SetActive(true);
        }
    }
}
