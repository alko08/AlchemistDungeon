using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMusic : MonoBehaviour
{
    private bool startPhase = true;
    // Start is called before the first frame update
    // void Start()
    // {
    //     // FindObjectOfType<AudioManager>().Pause("Theme");
    //     // FindObjectOfType<AudioManager>().Pause("BossTheme");
    //     // FindObjectOfType<AudioManager>().Play("LoseSound");
    // }

    // Update is called once per frame
    void Update()
    {
        // pause main theme
        bool themePlaying = FindObjectOfType<AudioManager>().isPlaying("Theme");
        if (themePlaying && startPhase)
            FindObjectOfType<AudioManager>().Pause("Theme");
            FindObjectOfType<AudioManager>().Pause("BossTheme");
            
            // play theme
            // bool losePlaying = FindObjectOfType<AudioManager>().isPlaying("LoseSound");
            if (startPhase) {
                FindObjectOfType<AudioManager>().Play("LoseSound");
                startPhase = false;
            }
            
        
        // // pause bosstheme
        // bool bossPlaying = FindObjectOfType<AudioManager>().isPlaying("BossTheme");
        // if (bossPlaying && startPhase)
        //     FindObjectOfType<AudioManager>().Pause("BossTheme");
        
        // play theme
        bool losePlaying = FindObjectOfType<AudioManager>().isPlaying("LoseSound");
        if (!losePlaying && !startPhase) {
            FindObjectOfType<AudioManager>().Play("Theme");
        }
    }
}
