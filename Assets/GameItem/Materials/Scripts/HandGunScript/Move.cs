using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    float Speed = 10f;
    float X = 0f;
    float Z = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        X = Input.GetAxis("Horizontal") * Speed;
        Z = Input.GetAxis("Vertical") * Speed;

        rb.velocity = new Vector3(X, 0f, Z);
    }
}
