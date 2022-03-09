using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPotion : MonoBehaviour
{
    public Transform movePoint;
    public SlimeBoss boss;
    public Transform art;


    // Update is called once per frame
    void Update() {
        boss.stop();
        transform.position = Vector3.MoveTowards(transform.position, 
            movePoint.position, 4 * Time.deltaTime);
        art.Rotate(new Vector3(0,0,1f));
        
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) {
            boss.shrink();
            Destroy(gameObject);
        }
        
    }
}
