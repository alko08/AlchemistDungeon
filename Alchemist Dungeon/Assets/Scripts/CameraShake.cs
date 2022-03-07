using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Camera cam;
    private bool zoom, shake, pause;
    private Vector3 temp;
    
    // Start is called before the first frame update
    void Start()
    {
        temp = transform.position;
        zoom = false;
        shake = false;
        pause = false;
        cam = this.GetComponent<Camera>();
        StartCoroutine(WaitCoroutine());
    }

    public void Update()
    {
        if(cam.orthographicSize > 2f && zoom) {
            cam.orthographicSize -= .001f;
            transform.position += new Vector3(0f, .001f, 0f);
            Debug.Log("-.001f");
        } else if(cam.orthographicSize < 9f && !pause && !shake) {
            cam.orthographicSize += .01f;
            transform.position -= new Vector3(0f, .01f, 0f);
            Debug.Log("-+.01f");
        } else if(cam.orthographicSize >= 9f) {
            cam.orthographicSize = 9f;
            transform.position = temp;
        }
    }

    IEnumerator WaitCoroutine() {
        yield return new WaitForSeconds(2f);
        zoom = true;
        yield return new WaitForSeconds(5f);
        zoom = false;
        pause = true;
        shake = true;
        yield return new WaitForSeconds(1f);
        pause = false;
        yield return new WaitForSeconds(4f);
        shake = false;
        yield return new WaitUntil(() => 
            cam.orthographicSize == 9f);
        this.enabled = false;
    }
}
