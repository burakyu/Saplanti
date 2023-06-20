using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 0.0f;
    public float jump = 0.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            speed = 1.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed = -1.0f;
        }
        else
        {
            speed = 0.0f;
        }
        _animator.SetFloat("speed",speed);
        r2d.velocity = new Vector2(speed, 0.0f);
    }
}
