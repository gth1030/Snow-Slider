using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerManager {

    public GameObject instance;
    [HideInInspector] public TerrainTracker m_terrainTracker;

    
    

	// Use this for initialization
	public void SetUp () {
        m_terrainTracker = instance.GetComponent<TerrainTracker>();
    }

    public void ReSet()
    {
        instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        instance.GetComponent<PlayerHealth>().Revive();
        m_terrainTracker.aliveZoneCounter = 1;
    }
	


   
}
