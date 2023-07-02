using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 0.0f;
    [SerializeField] private float jumpPower = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera;
    private SpriteRenderer _spriteRenderer;

    bool isGrounded;
    public Transform GroundPosition;
    public LayerMask GroundLayer;
    public float GroundRadius;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        onGroundCheck();
        if (Input.GetKey(KeyCode.D))
        {
            speed = 1.0f;
            _spriteRenderer.flipX = false;
            charPos = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            transform.position = charPos;
            _animator.SetFloat("speed", speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed = -1.0f;
            _spriteRenderer.flipX = true;
            charPos = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            transform.position = charPos;
            _animator.SetFloat("speed", speed);
        }
        else
        {
            speed = 0.0f;
        }
        
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpPower*0.1f);
        }

        void onGroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(GroundPosition.position,GroundRadius,GroundLayer);
        }
        
    }
 
}
