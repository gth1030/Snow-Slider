using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [HideInInspector]public GameObject target;


    private Vector3 offset;

    // Use this for initialization
    void Start () {
	}


    public void SetupCamera()
    {
        offset = transform.position - target.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null && offset != null)
            transform.position = target.transform.position + offset;
	}
}
