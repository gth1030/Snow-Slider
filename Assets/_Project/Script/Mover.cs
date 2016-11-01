using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    [HideInInspector] public float moveHorizontal;
    [HideInInspector] public float moveVertical;

    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
    }

    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
        float turn = moveHorizontal * turnSpeed * Time.deltaTime;
        Quaternion turnrotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnrotation);
    }


    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        Turn();
        rb.AddForce(movement * speed);
    }
}
