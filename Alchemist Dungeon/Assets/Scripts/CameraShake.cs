using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Camera cam;
    private bool zoom, shake, pause, left;
    private Vector3 temp, temp2;
    public GameObject scroll;
    
    // Start is called before the first frame update
    void Start()
    {
        temp = transform.position;
        zoom = false;
        shake = false;
        pause = false;
        left = false;
        cam = this.GetComponent<Camera>();
        StartCoroutine(WaitCoroutine());
    }

    public void Update()
    {
        if(cam.orthographicSize > 2f && zoom) {
            if (cam.orthographicSize > 5.55) {
                cam.orthographicSize -= .01f;
                transform.position += new Vector3(0f, .01f, 0f);
                // Debug.Log("-.01f");
            }
            
        } else if(cam.orthographicSize < 9f && !pause && !shake) {
            cam.orthographicSize += .1f;
            transform.position -= new Vector3(0f, .1f, 0f);
            // Debug.Log("+.1f");
        } else if (!pause && shake) {
            if (Vector3.Distance(transform.position, temp2) == 0f) {
                if (left) {
                    transform.position -= new Vector3(.05f, 0f, 0f);
                } else {
                    transform.position += new Vector3(.05f, 0f, 0f);
                }
                left = !left;
            }else {
                transform.position = temp2;
            }
        } else if(cam.orthographicSize >= 9f) {
            cam.orthographicSize = 9f;
            transform.position = temp;
        } else if (pause) {
            temp2 = transform.position;
        }
    }

    IEnumerator WaitCoroutine() {
        LeanTween.scale(scroll, new Vector3(0,0,0), 0.5f);
        yield return new WaitForSeconds(2f);
        zoom = true;
        yield return new WaitForSeconds(5f);
        zoom = false;
        pause = true;
        shake = true;
        yield return new WaitForSeconds(1f);
        pause = false;
        yield return new WaitForSeconds(2.5f);
        shake = false;
        yield return new WaitUntil(() => 
            cam.orthographicSize == 9f);
        LeanTween.scale(scroll, new Vector3(1,1,1), 0.5f);
        this.enabled = false;
    }
}
