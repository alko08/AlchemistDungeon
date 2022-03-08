using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : MonoBehaviour
{
    private bool happy, angryShake, surpised, fight, left, shake, centerLook,
        leftDown, leftUp, rightDown, rightUp, angry;
    public Animator anim;
    private float moveSpeed = 1f;
    public Transform movePoint;
    private Transform slimePoint;
    public GameObject slime;
    private Vector3 start;
    private MoveAnim playerScript; 

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("PlayerController").GetComponent<MoveAnim>();
        playerScript.canMove = false;

        happy = true;
        left = true;
        rightUp = true;
        
        angryShake = false;
        surpised = false; 
        fight = false;
        shake = false;
        leftDown = false;
        leftUp = false;
        rightDown = false;
        centerLook = false;
        angry = false;


        slimePoint = slime.transform;
        start = movePoint.position;
        
        animateFunc();
        // shakes();
        StartCoroutine(AnimationCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        slimePoint.position = Vector3.MoveTowards(slimePoint.position, 
                             movePoint.position, moveSpeed * Time.deltaTime);
        if (shake) {
            // Debug.Log(Vector3.Distance(slimePoint.position, movePoint.position));
            if (Vector3.Distance(slimePoint.position, movePoint.position) <= 0f) {
                if (left) {
                    movePoint.position = start + new Vector3(.1f, 0, 0);
                    left = !left;
                } else {
                    movePoint.position = start - new Vector3(.1f, 0, 0);
                    left = !left;
                }
            }
        } else {
            movePoint.position = start;
        }

        // if ()
    }

    void animateFunc() {
        // Debug.Log(surpised);
        anim.SetBool("Happy", happy);
        anim.SetBool("AngryShake", angryShake);
        anim.SetBool("Surpised", surpised);
        anim.SetBool("LeftUp", leftUp);
        anim.SetBool("LeftDown", leftDown);
        anim.SetBool("RightUp", rightUp);
        anim.SetBool("RightDown", rightDown);
        anim.SetBool("CenterDown", centerLook);
        anim.SetBool("Angry", angry);
    }

    IEnumerator AnimationCoroutine() {
        yield return new WaitForSeconds(1f);
        happy = false;
        surpised = true;
        animateFunc();
        yield return new WaitForSeconds(1f);
        happy = true;
        surpised = false;
        animateFunc();
        LeanTween.scale(slime, new Vector3(7,7,7), 5f).setOnComplete(shakes);
    }

    void shakes() {
        centerLook = true;
        rightUp = false;
        happy = false;
        surpised = false;
        angryShake = true;
        animateFunc();
        StartCoroutine(endCoroutine());
    }

    IEnumerator endCoroutine() {
        Vector3 temp2 = slimePoint.position;
        yield return new WaitForSeconds(1f);
        shake = true;
        FindObjectOfType<AudioManager>().Play("ROAR");
        yield return new WaitForSeconds(4f);
        shake = false;
        happy = true;
        surpised = false;
        angryShake = false;
        angry = true;
        animateFunc();
        slimePoint.position = temp2;
        yield return new WaitForSeconds(1f);
        angry = false;
        animateFunc();
        playerScript.canMove = true;
        fight = true;
    }
}
