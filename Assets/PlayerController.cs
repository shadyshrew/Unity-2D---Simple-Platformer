using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private enum State { idle, running, jumping, falling};
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    private void Update() {
        float hdirection = Input.GetAxis("Horizontal");
        if (hdirection < 0)
        {
            player.velocity = new Vector2(-5, player.velocity.y);
            transform.localScale = new Vector2(-1,1);
        }
        else if (hdirection > 0)
        {
            player.velocity = new Vector2(5, player.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
           
        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            player.velocity = new Vector2(player.velocity.x, 10f);
            state = State.jumping;
        }
        VelocityState();
        anim.SetInteger("state",(int)state);
    }

    private void VelocityState()
    {
        if (state == State.jumping)
        {
            if(player.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(player.velocity.x) > 2f)
        {
            state = State.running;

        }
        else {
            state = State.idle;
        }
    }

}
