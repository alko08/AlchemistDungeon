using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Pause("Theme");
        FindObjectOfType<AudioManager>().Pause("BossTheme");
        FindObjectOfType<AudioManager>().Play("LoseSound");
    }

    // Update is called once per frame
    void Update()
    {
        bool isPlaying = FindObjectOfType<AudioManager>().isPlaying("LoseSound");
        
        if (!isPlaying)
            FindObjectOfType<AudioManager>().Play("Theme");
    }
}
