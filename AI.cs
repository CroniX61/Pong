using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{
    public float multiplier = 1.0f;
    public int collisionAngleMultiplier = 1;
    Rigidbody rigidbody;
    public Rigidbody ball;
    public float ForceMultiplier;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.position.y < rigidbody.position.y)
        {
            Vector3 force = new Vector3(0, ForceMultiplier * (-10), 0) * multiplier;
            rigidbody.AddForce(force);
        }
        else
        {
            Vector3 force = new Vector3(0, ForceMultiplier * 10, 0) * multiplier;
            rigidbody.AddForce(force);
        }
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
}