using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update() {
        float hdirection = Input.GetAxis("Horizontal");
        float vdirection = Input.GetAxis("Vertical");
        if (hdirection < 0)
        {
            player.velocity = new Vector2(-5, player.velocity.y);
            transform.localScale = new Vector2(-1,1);
            anim.SetBool("running", true);
        }
        else if (hdirection > 0)
        {
            player.velocity = new Vector2(5, player.velocity.y);
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.velocity = new Vector2(player.velocity.x, 27);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.velocity = new Vector2(player.velocity.x, -5);
        }
    }
    // Start is called before the first frame update

}
