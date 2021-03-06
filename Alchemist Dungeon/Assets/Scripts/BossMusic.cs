using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool bossPlaying = FindObjectOfType<AudioManager>().isPlaying("BossTheme");
        if (!bossPlaying)
            FindObjectOfType<AudioManager>().Play("BossTheme");
        
        bool themePlaying = FindObjectOfType<AudioManager>().isPlaying("Theme");
        if (themePlaying)
            FindObjectOfType<AudioManager>().Pause("Theme");
    }
}
