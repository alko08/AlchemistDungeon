using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Door" + other.name);
        if (other.transform.tag == "Player") {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
