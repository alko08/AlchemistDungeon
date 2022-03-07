using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : MonoBehaviour
{
    private bool happy, angryShake, surpised, fight, left;
    public Animator anim;
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Transform slime;
    private int  i = 1;
    private Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
        happy = false;
        angryShake = false;
        surpised = true; 
        fight = false;
        left = true;
        animateFunc();
        start = movePoint.position;
        // shakes();
        StartCoroutine(AnimationCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        slime.position = Vector3.MoveTowards(slime.position, 
                             movePoint.position, moveSpeed * Time.deltaTime);
        if (angryShake) {
            Debug.Log(Vector3.Distance(slime.position, movePoint.position));
            if (Vector3.Distance(slime.position, movePoint.position) <= 0f) {
                if (left) {
                    movePoint.position = start + new Vector3(.5f, 0, 0);
                    left = !left;
                } else {
                    movePoint.position = start - new Vector3(.5f, 0, 0);
                    left = !left;
                }
            }
        } else {
            movePoint.position = start;
        }
    }

    void animateFunc() {
        anim.SetBool("Happy", happy);
        anim.SetBool("AngryShake", angryShake);
        anim.SetBool("Surpised", surpised);
    }

    IEnumerator AnimationCoroutine() {
        yield return new WaitForSeconds(1f);
        happy = true;
        surpised = false;
        animateFunc();
        LeanTween.scale(gameObject, new Vector3(7,7,7), 5f).setOnComplete(shakes);
    }

    void shakes() {
        happy = false;
        surpised = false;
        angryShake = true;
        animateFunc();
        StartCoroutine(endCoroutine());
    }

    IEnumerator endCoroutine() {
        Vector3 temp2 = slime.position;
        yield return new WaitForSeconds(5f);
        happy = true;
        surpised = false;
        angryShake = false;
        animateFunc();
        slime.position = temp2;
        yield return new WaitForSeconds(1f);
        fight = true;
    }
}
