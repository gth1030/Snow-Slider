using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<TerrainTracker>().playerAlive = false;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
