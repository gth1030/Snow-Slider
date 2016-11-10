using UnityEngine;
using System.Collections;

public class KittenAnimator : MonoBehaviour {


    private Animator anim;
    private TerrainTracker m_terrainTracker;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        m_terrainTracker = GetComponent<TerrainTracker>();
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Vertical");
        anim.SetFloat("speed", move);
        anim.SetBool("onSnow", m_terrainTracker.onSnow);
/*        if (anim.GetBool("onSnow") == false && anim.GetFloat("speed") == 0 && move != 0)
            anim.SetFloat("speed", move);
        else
            anim.SetFloat("speed", 0);
        if (anim.GetBool("onSnow") != m_terrainTracker)
            anim.SetBool("onSnow", m_terrainTracker.onSnow); */
	}
}
