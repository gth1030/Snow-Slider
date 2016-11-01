using UnityEngine;
using System.Collections;

public class rollOnMove : MonoBehaviour {

    private Vector3 initialLoc;
    private RollBarrel parentRoll;

	void Start () {
        initialLoc = transform.position;
        parentRoll = GetComponentInParent<RollBarrel>();
	}
	
	void Update () {
        if (!parentRoll.turning)
            transform.Rotate(Vector3.down * Time.deltaTime * 20 * parentRoll.speed);

	}
}
