using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("BossTheme");
    }

    // Update is called once per frame
    void Update()
    {
        bool isPlaying = FindObjectOfType<AudioManager>().isPlaying("Theme");
        
        if (isPlaying)
            FindObjectOfType<AudioManager>().Pause("Theme");
    }
}
