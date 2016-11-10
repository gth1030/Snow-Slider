using UnityEngine;
using System.Collections;

public class SpawnBarrel : MonoBehaviour {

    public GameObject[] barrelSpawns;


	void Start () {
	    foreach(GameObject barrelSpawn in barrelSpawns)
        {
            barrelSpawn.GetComponent<BarrelSpawnInfo>().instantiateBarrel();
        }
        activateBarrel();
    }

    public void activateBarrel()
    {
        foreach (GameObject barrelSpawn in barrelSpawns)
        {
            barrelSpawn.GetComponent<BarrelSpawnInfo>().barrel.GetComponent<RollBarrel>().BarrelReSet();
            barrelSpawn.GetComponent<BarrelSpawnInfo>().barrel.GetComponent<RollBarrel>().ableMoves();
        }
    }

    public void deactivateBarrel()
    {
        foreach (GameObject barrelSpawn in barrelSpawns)
        {
            barrelSpawn.GetComponent<BarrelSpawnInfo>().barrel.GetComponent<RollBarrel>().disableMoves();
        }
    }
	

    


}
