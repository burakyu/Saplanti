using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float jumpPower = 1.0f;
    [SerializeField] private float movementSpeed;
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

    void Update()
    {
        OnGroundCheck();
        CharacterMovement();
    }

    void CharacterMovement()
    {
        charPos = new Vector3(transform.position.x + (Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed), transform.position.y);
        transform.position = charPos;
        _animator.SetFloat("speed", Input.GetAxis("Horizontal"));

        if (Input.GetAxis("Horizontal") < 0) _spriteRenderer.flipX = true;
        else if (Input.GetAxis("Horizontal") > 0) _spriteRenderer.flipX = false;

        if (Input.GetAxis("Vertical") > 0 && isGrounded) r2d.velocity = new Vector2(r2d.velocity.x, jumpPower * 0.1f);
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(GroundPosition.position, GroundRadius, GroundLayer);
    }
}
