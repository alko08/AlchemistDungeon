using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveAnim : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public LayerMask slime;
    public Animator anim;
    private bool moving;
    private bool sliding;
    private bool hitWall;
    public bool canMove;
    
    
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
        hitWall = false;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                             movePoint.position, moveSpeed * Time.deltaTime);
                             
        if (canMove && Vector3.Distance(transform.position, movePoint.position) <= .05f) {
            if (hitWall) {
                FindObjectOfType<AudioManager>().Play("Thud");
                hitWall = false;
            }

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
                    while (Physics2D.OverlapCircle(movePoint.position, 0f, slime)) {
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0f, whatStopsMovement)) {
                            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                            sliding = true;
                            // Debug.Log("Horizontal Slime"); 
                        } else {
                            hitWall = true;
                            break;
                        }
                    }
                }else {
                    hitWall = true;
                }
                
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0f, whatStopsMovement)) {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    // Debug.Log("Vertical");
                    while (Physics2D.OverlapCircle(movePoint.position, 0f, slime)) {
                        if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0f, whatStopsMovement)) {
                            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                            sliding = true;
                            // Debug.Log("Vertical Slime");
                        } else {
                            hitWall = true;
                            break;
                        }
                    }
                } else {
                    hitWall = true;
                }
                
            }
        } else if (canMove) { // Animate Movement
            moving = true;
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

    public void deathTween() {
        canMove = false;
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f).setOnComplete(destroyMe);
    }
    void destroyMe() {
        SceneManager.LoadScene("SceneLose");
        Destroy(gameObject);
    }
}
