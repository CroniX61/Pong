using UnityEngine;
using System.Collections;
using System;

public class Cont : MonoBehaviour
{
    public float multiplier = 1.0f;
    public int collisionAngleMultiplier = 1;
    Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        float vertical = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(0, vertical*10, 0) * multiplier;
        rigidbody.AddForce(force);
        vertical = Input.GetAxis("Mouse Y");
        force = new Vector3(0, vertical*10, 0) * multiplier;
        rigidbody.AddForce(force);
    }



    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Ball"))
        {
            GameObject ball = gameObject;
            Ball ballController = ball.GetComponent<Ball>();
            float shift = ball.transform.position.y - transform.position.y;
            Vector3 force = new Vector3(0, 1, 0) * shift * collisionAngleMultiplier;
            ball.GetComponent<Rigidbody>().AddForce(force);
        }
    }

    /*
	Vector3 normalizeForce(Vector3 force, BallController forBall) {
		float multiplier = forBall.initialForceMultiplier / (force.x + force.z);
		print (String.Format ("Speed is {0}, and multiplier is {1}", force, multiplier));
		return force * multiplier;
	}
	*/
}