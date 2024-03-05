using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0;
    public float gravity = 9.8f;
    public float jumpForce;
    public float walkspeed;
    public float runSpeed;
    public Animator animator;

    private float curSpeed;

    private Vector3 _moveVector;
    private CharacterController _characterController;

    private void PlayerConrollsUpdate()
    {
        var movementDirection = 0;
        _moveVector = Vector3.zero;

        animator.SetBool("isJumping", false);
        animator.SetBool("isJumpingForward", false);

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            movementDirection = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            movementDirection = 3;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            movementDirection = 2;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            movementDirection = 4;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity -= jumpForce;

            if (Input.GetKey(KeyCode.W))
            {

                animator.SetBool("isJumpingForward", true);
            }

            else animator.SetBool("isJumping", true);
        }

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            curSpeed = runSpeed;

            if (Input.GetKey(KeyCode.W)) movementDirection = 5;
            if (Input.GetKey(KeyCode.S)) movementDirection = 6;
            if (Input.GetKey(KeyCode.D)) movementDirection = 7;
            if (Input.GetKey(KeyCode.A)) movementDirection = 8;

        }
        else
        {
            curSpeed = walkspeed;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) {_moveVector /= 1.41f; }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) _moveVector /= 1.41f;
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) _moveVector /= 1.41f;
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) _moveVector /= 1.41f;
        animator.SetInteger("run direction", movementDirection);
    }

    private void PlayerPositionFixedUpdate()
    {
        _characterController.Move(_moveVector * curSpeed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        curSpeed = walkspeed;
        _characterController = GetComponent<CharacterController>();
        animator.SetFloat("runSpeed", runSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPositionFixedUpdate();
        
    }

    private void Update()
    {
        PlayerConrollsUpdate();
    }
}
