using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tes : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var vec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * (Time.deltaTime * 4);
        this.transform.Translate(vec);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(transform.up);
            _rigidbody2D.AddForce(transform.up*400);
        }
    }

    private void FixedUpdate()
    {
     
    }
}
