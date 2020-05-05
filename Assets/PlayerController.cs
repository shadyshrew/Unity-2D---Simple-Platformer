using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public Animator anim;
    private void Update() {
        
        if (Input.GetKey(KeyCode.A))
        {
            player.velocity = new Vector2(-5, player.velocity.y);
            transform.localScale = new Vector2(-1,1);
            anim.SetBool("running", true);
        }
        else if (Input.GetKey(KeyCode.D))
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
    void Start()
    {
    }
}
