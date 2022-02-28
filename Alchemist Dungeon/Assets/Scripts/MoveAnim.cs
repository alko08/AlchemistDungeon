using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnim : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public LayerMask slime;
    public Animator anim;
    private bool moving;
    private bool sliding;
    
    
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        anim.SetBool("Walk", false);
        anim.SetBool("Slide", false);
        anim.SetBool("Up", true);
        anim.SetBool("Down", false);
        anim.SetBool("Right", false);
        anim.SetBool("Left", false);
        moving = false;
        sliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                             movePoint.position, moveSpeed * Time.deltaTime);
                             
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) {
            if (moving) {
                moving = false;
                sliding = false;
            } else {
                anim.SetBool("Walk", false);
                anim.SetBool("Slide", false);
            }
        
            // move the movePoint to one space away in the intended direction
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0f, whatStopsMovement)) {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    // Debug.Log("Horizontal");
                    while (Physics2D.OverlapCircle(movePoint.position, 0f, slime)
                    && !Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0f, whatStopsMovement)) {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        // Debug.Log("Horizontal Slime");
                    }
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0f, whatStopsMovement)) {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    // Debug.Log("Vertical");
                    while (Physics2D.OverlapCircle(movePoint.position, 0f, slime) 
                    && !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0f, whatStopsMovement)) {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        // Debug.Log("Vertical Slime");
                    }
                }
            }
        } else { // Animate Movement
            moving = true;
            sliding = sliding || Vector3.Distance(transform.position, movePoint.position) > 1.5f;
            // Debug.Log(Vector3.Distance(transform.position, movePoint.position));
            anim.SetBool("Slide", sliding);
            anim.SetBool("Walk", true);

            // Debug.Log("Walk");
            if(Input.GetAxisRaw("Horizontal") > 0f) {
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
                anim.SetBool("Right", true);
                anim.SetBool("Left", false);
            } else if(Input.GetAxisRaw("Horizontal") < 0f) {
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
                anim.SetBool("Right", false);
                anim.SetBool("Left", true);
            } else if (Input.GetAxisRaw("Vertical") > 0f) {
                anim.SetBool("Up", true);
                anim.SetBool("Down", false);
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);
            } else if (Input.GetAxisRaw("Vertical") < 0f) {
                anim.SetBool("Up", false);
                anim.SetBool("Down", true);
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);
            }
        }
    }
}
