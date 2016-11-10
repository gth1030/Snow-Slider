using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float maximumHealth;
    public float health;
    public GameObject deathObj;




    public bool isAlive()
    {
        if (health <= 0)
            return false;
        return true;
    }

    public void Revive()
    {
        health = maximumHealth;
        GetComponent<TerrainTracker>().onSnow = false;
        GetComponent<Mover>().enabled = true;
        gameObject.SetActive(true);
    }


    public void onDeath()
    {
        gameObject.SetActive(false);
        GameObject exp = Instantiate(deathObj, transform.position, transform.rotation) as GameObject;
        GetComponent<Mover>().enabled = false;
        Destroy(exp, 10);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
