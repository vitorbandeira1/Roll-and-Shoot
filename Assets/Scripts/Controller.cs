using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Vertical");
        rb.AddForce(0.0f, 0.0f, 2.0f * hInput, ForceMode.Impulse);
        
    }
}
