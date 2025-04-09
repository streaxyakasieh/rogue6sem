using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float hor = Input.GetAxis("Debug Horizontal");
        float ver = Input.GetAxis("Debug Vertical");
        _rigidbody2D.linearVelocity = new UnityEngine.Vector2(hor, ver) * speed;
    }
}
