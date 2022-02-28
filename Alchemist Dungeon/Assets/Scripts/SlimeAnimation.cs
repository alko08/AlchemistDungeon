using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    public GameObject PlayerObject;
    public float moveSpeed = 2f;
    public Transform movePoint;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObject.GetComponent<MoveAnim>().enabled = false;
        movePoint.parent = null;
        StartCoroutine(Tutorial1Coroutine());
    }

    IEnumerator Tutorial1Coroutine() {
        yield return new WaitForSeconds(2);
        movePoint.position += new Vector3(-3f, 0f, 0f);
        yield return new WaitUntil(() => (Vector3.Distance(transform.position, movePoint.position) <= .05f));
        movePoint.position += new Vector3(0f, 1f, 0f);
        yield return new WaitUntil(() => (Vector3.Distance(transform.position, movePoint.position) <= .05f));
        PlayerObject.GetComponent<MoveAnim>().enabled = true;
        Destroy(gameObject, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                             movePoint.position, moveSpeed * Time.deltaTime);   
    }
}
