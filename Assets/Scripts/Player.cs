using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    [SerializeField]
    private Rigidbody2D myBody;

    private Animator anim;
    private SpriteRenderer sr;
    private const string WALK_ANIMATION = "Walk";

    private bool isJumpKeyPressed = false;
    private const int maxJumpTimes = 1;
    private int currentjumpTimes = 0;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        if (Input.GetButtonDown("Jump") && currentjumpTimes < maxJumpTimes)
        {
            isJumpKeyPressed = true;
        }
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }
    private void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

    }

    private void AnimatePlayer()
    {
        //key: a, -1,d,1
        if(movementX >0) // go to the right side
        {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if(movementX <0)//go to the left side
        {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentjumpTimes=0;

    }

    private void PlayerJump()
    {
        if (isJumpKeyPressed && currentjumpTimes <maxJumpTimes)
        {
            currentjumpTimes++;
            isJumpKeyPressed = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
