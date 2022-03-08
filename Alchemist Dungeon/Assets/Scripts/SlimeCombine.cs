using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCombine : MonoBehaviour
{
    public Transform boss;
    private float moveSpeed = 4f;
    private bool moving;
    

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        StartCoroutine(AnimationCoroutine());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (moving) {
            transform.position = Vector3.MoveTowards(transform.position, 
                boss.position, moveSpeed * Time.deltaTime);

            if (boss.position.x < transform.position.x) {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    IEnumerator AnimationCoroutine() {
        yield return new WaitForSeconds(2f);
        moving = true;
        yield return new WaitUntil(() => 
            Vector3.Distance(transform.position, boss.position) <= 1f);
        Destroy(gameObject);
    }
}
