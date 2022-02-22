using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnGrid : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                             movePoint.position, moveSpeed * Time.deltaTime);
                             
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) {
        
        
            // move the movePoint to one space away in the intended direction
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Horizontal"), 0f);
            }
        }
    }
}
