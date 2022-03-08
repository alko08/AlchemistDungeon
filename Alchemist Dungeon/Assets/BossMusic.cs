using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Pause("Theme");
        FindObjectOfType<AudioManager>().Play("BossTheme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
