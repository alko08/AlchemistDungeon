using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    public Transform movePoint;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        StartCoroutine(WalkCoroutine());   
    }

    IEnumerator WalkCoroutine() {
        yield return new WaitForSeconds(.5f);
        movePoint.position += new Vector3(0f, 4f, 0f);
        anim.SetBool("Walk", true);
        yield return new WaitUntil(() => 
            Vector3.Distance(transform.position, movePoint.position) <= .05f);
        anim.SetBool("Walk", false);
        this.enabled = false;
    }
}
