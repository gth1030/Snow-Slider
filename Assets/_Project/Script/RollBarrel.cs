using UnityEngine;
using System.Collections;

public class RollBarrel : MonoBehaviour {

    public float[] rollPositionsX;
    public float[] rollPositionsZ;
    public float speed;
    public float rotateSpeedRatio;
    [HideInInspector] public bool turning;


    private Transform initialPosition;
    private float[] rollPatternX;
    private float[] rollPatternZ;
    private float[] nextDestination;
    private Rigidbody rb;
    private int locationCounter;
    private Quaternion toRotation;

	void Start () {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform;
        rollPatternX = new float[rollPositionsX.Length + 1];
        rollPatternZ = new float[rollPositionsZ.Length + 1];
        for (int i = 0; i < rollPositionsX.Length; i++)
        {
            rollPatternX[i] = rollPositionsX[i] + initialPosition.position.x;
            rollPatternZ[i] = rollPositionsZ[i] + initialPosition.position.z;
        }
        rollPatternX[rollPatternX.Length - 1] = initialPosition.position.x;
        rollPatternZ[rollPatternZ.Length - 1] = initialPosition.position.z;
        nextDestination = new float[] { rollPatternX[0], rollPatternZ[0] };
        locationCounter = 0;
        turning = false;
        turnToPositoin(nextDestination);
    }
	

    void turnToPositoin (float[] position)
    {
        turning = true;
        Vector3 direction = new Vector3(position[0] - transform.position.x, 0, position[1] - transform.position.z);
        toRotation = Quaternion.LookRotation(direction);
    }

    void rotateBarrel()
    {
        if (!checkForDirection(.1f * speed))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotateSpeedRatio * speed * Time.deltaTime);
            rb.velocity = new Vector3(0f, 0f, 0f);
        } else
        {
            transform.rotation = toRotation;
            turning = false;
        }
    }


    bool checkForDirection(float threshHold)
    {
        if (Mathf.Abs(toRotation.eulerAngles.x - transform.rotation.eulerAngles.x) > threshHold)
            return false;
        if (Mathf.Abs(toRotation.eulerAngles.y - transform.rotation.eulerAngles.y) > threshHold)
            return false;
        if (Mathf.Abs(toRotation.eulerAngles.z - transform.rotation.eulerAngles.z) > threshHold)
            return false;
        return true;
    }

    void move()
    {
        if (getEstimate2Ddistance(transform.position, new Vector3(nextDestination[0], 0.0f, nextDestination[1])) < .03 * speed)
        {
            transform.position = new Vector3(nextDestination[0], transform.position.y, nextDestination[1]);
            locationCounter = (locationCounter + 1) % rollPatternX.Length;
            nextDestination[0] = rollPatternX[locationCounter];
            nextDestination[1] = rollPatternZ[locationCounter];
            turnToPositoin(nextDestination);
        }
        rb.velocity = speed * (new Vector3(nextDestination[0], transform.position.y, nextDestination[1]) - transform.position).normalized;
    }



	void Update () {
        if (!turning)
            move();
        else
            rotateBarrel();
	
	}

    private float getEstimate2Ddistance(Vector3 v1, Vector3 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.z - v2.z, 2));
    }
}
