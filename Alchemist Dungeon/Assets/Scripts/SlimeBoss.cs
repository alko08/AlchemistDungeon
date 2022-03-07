using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : MonoBehaviour
{
    private bool happy = false;
    private bool angryShake = false;
    private bool surpised = true;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        animateFunc();
        StartCoroutine(AnimationCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        LeanTween.scale(gameObject, new Vector3(7,7,7), 7f);
    }
}
