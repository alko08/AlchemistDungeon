using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("LoseSound");
    }

    // Update is called once per frame
    void Update()
    {
        // if (!GetComponent<AudioSource>().isPlaying)
        //     FindObjectOfType<AudioManager>().Play("Theme");
    }
}
