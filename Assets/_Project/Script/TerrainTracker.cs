using UnityEngine;
using System.Collections;



public class TerrainTracker : MonoBehaviour {

    public float minSlideSpeed;
    public float artificial_gravity;
    [HideInInspector]
    public int aliveZoneCounter;
    [HideInInspector]
    public bool playerAlive;
    [HideInInspector] public bool onSnow;


    private int aliveZoneLayer;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        onSnow = false;
        rb = GetComponent<Rigidbody>();
        aliveZoneLayer = LayerMask.NameToLayer("Alive Zone");
	}
	


    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.layer == aliveZoneLayer)
            aliveZoneCounter = 2;
        if (other.tag == "snow zone")
            onSnow = true;
        else if (other.tag == "safe zone")
            onSnow = false;
    }



    void Update()
    {
        if (onSnow)
        {
            float currentSpeed = rb.velocity.magnitude;
            if (currentSpeed < minSlideSpeed)
            {
                rb.velocity = new Vector3(
                    transform.forward.x * minSlideSpeed, 
                    -artificial_gravity, 
                    transform.forward.z * minSlideSpeed);
            }

        }
        if (aliveZoneCounter > 0)
        {
            aliveZoneCounter--;
        } else
        {
            if (Time.time > 1)
                GetComponent<PlayerHealth>().health = 0;
        }
    }


}
