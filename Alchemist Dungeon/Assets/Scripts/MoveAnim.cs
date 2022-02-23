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
    private bool running;
    
    
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        anim.SetBool("Walk", false);
        anim.SetBool("Right", true);
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                             movePoint.position, moveSpeed * Time.deltaTime);
                             
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) {
            if (running) {
                running = false;
            } else {
                anim.SetBool("Walk", false);
            }
            // Debug.Log("Stop");
        
            // move the movePoint to one space away in the intended direction
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0f, whatStopsMovement)) {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    Debug.Log("Horizontal");
                    while (Physics2D.OverlapCircle(movePoint.position, 0f, slime)
                    && !Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0f, whatStopsMovement)) {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        Debug.Log("Horizontal Slime");
                    }
                }
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0f, whatStopsMovement)) {
                    Debug.Log("Stops Movement");
                } else {
                    Debug.Log("No Slime");
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0f, whatStopsMovement)) {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        Debug.Log("Vertical");
                        while (Physics2D.OverlapCircle(movePoint.position, 0f, slime) 
                        && !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0f, whatStopsMovement)) {
                            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                            Debug.Log("Vertical Slime");
                        }
                    }
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0f, whatStopsMovement)) {
                        Debug.Log("Stops Movement");
                    } else {
                        Debug.Log("No Slime");
                    }
            }else {
                // Debug.Log("Didnt Move");
            }
        } else {
            // Debug.Log("Walk");
            running = true;
            anim.SetBool("Walk", true);
            if(Input.GetAxisRaw("Horizontal") > 0f) {
                anim.SetBool("Right", true);
            } else if(Input.GetAxisRaw("Horizontal") < 0f) {
                anim.SetBool("Right", false);
            }
        }
    }
}
