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
        bool bossPlaying = FindObjectOfType<AudioManager>().isPlaying("BossTheme");
        if (bossPlaying)
            FindObjectOfType<AudioManager>().Pause("BossTheme");
            
        bool themePlaying = FindObjectOfType<AudioManager>().isPlaying("Theme");    
        if (themePlaying)
            FindObjectOfType<AudioManager>().Pause("Theme");
        
        bool winPlaying = FindObjectOfType<AudioManager>().isPlaying("WinSound");
        if (!winPlaying)
            FindObjectOfType<AudioManager>().Play("Theme");
    }
}
