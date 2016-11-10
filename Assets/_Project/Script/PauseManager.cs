using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    [HideInInspector] public GameObject player;

    public void PauseGameSystem()
    {
        player.GetComponent<TerrainTracker>().isPause = true;
    }

    public void UnPauseGameSystem()
    {
        player.GetComponent<TerrainTracker>().isPause = false;
    }


}
