using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMovement : MonoBehaviour
{

  private Rigidbody2D rb;

  private Animator animator;

  bool jumping = true;
  bool falling = true;

  public AudioSource step;
  public AudioSource jump;
  public AudioSource land;

  // Start is called before the first frame update
  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

  }

  // Update is called once per frame
  void FixedUpdate()
    {
        if(Mathf.Abs(rb.velocity.x) > 0.1)
        {
          animator.SetBool("walking", true);
          if (rb.velocity.x > 0)
          {
              transform.localScale = (new Vector3(1, 1, 1));
          }
          else
          {
              transform.localScale = (new Vector3(-1, 1, 1));

          }
          if (!step.isPlaying && !jumping && !falling)
            step.Play();
        }
        else
        {
          animator.SetBool("walking", false);
        }

        if (!jumping && rb.velocity.y > 0.1)
        {
          jumping = true;
          animator.SetTrigger("jumping");
          if (!jump.isPlaying)
            jump.Play();
        } 
        else if (!falling && rb.velocity.y < -0.1)
        {
          animator.SetTrigger("falling");
          falling = true;
        }
        else if(falling && Mathf.Abs(rb.velocity.y) <= 0.1)
        {
          animator.SetTrigger("onfloor");
          jumping = false;
          falling = false;
          land.Play();  
        }

  }
}
