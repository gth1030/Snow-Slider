using UnityEngine;
using System.Collections;

public class BarrelSpawnInfo : MonoBehaviour {

    public float[] rollPositionsX;
    public float[] rollPositionsZ;
    public float speed;
    public float rotateSpeedRatio;
    public GameObject barrelPrefeb;
    [HideInInspector] public GameObject barrel;

    public void instantiateBarrel()
    {
        barrel = Instantiate(barrelPrefeb, transform.position, transform.rotation) as GameObject;
        RollBarrel rollB = barrel.GetComponent<RollBarrel>();
        rollB.BarrelInitialize(rollPositionsX, rollPositionsZ, speed, rotateSpeedRatio);
    }

}
