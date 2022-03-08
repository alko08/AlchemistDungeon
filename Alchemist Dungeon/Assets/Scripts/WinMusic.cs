using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Pause("Theme");
        FindObjectOfType<AudioManager>().Play("WinSound");
    }

    // Update is called once per frame
    void Update()
    {
        bool isPlaying = FindObjectOfType<AudioManager>().isPlaying("WinSound");
        
        if (!isPlaying)
            FindObjectOfType<AudioManager>().Play("Theme");
    }
}
