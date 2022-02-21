using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static string SceneDied = "MainMenu";

    // Start is called before the first frame update
    void Start (){
        string thisLevel = SceneManager.GetActiveScene().name;
        if ((thisLevel != "SceneLose") && (thisLevel != "SceneWin")){
            SceneDied = thisLevel;
        }
    }
    public void StartGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartGame() {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void ReplayGame (){
        SceneManager.LoadScene(SceneDied);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
