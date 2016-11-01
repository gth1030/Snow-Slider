using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerManager {

    public GameObject instance;
    [HideInInspector] public TerrainTracker m_terrainTracker;

    private Mover m_playerMover;
    

	// Use this for initialization
	public void SetUp () {
        m_playerMover = instance.GetComponent<Mover>();
        m_terrainTracker = instance.GetComponent<TerrainTracker>();
    }

    public void ReSet()
    {
        instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        m_terrainTracker.ReSet();
        instance.SetActive(true);
        m_terrainTracker.aliveZoneCounter = 1;
    }
	
	// Update is called once per frame


    void DisableControl()
    {
        m_playerMover.enabled = false;
    }

   
}
