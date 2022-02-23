using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static string SceneDied = "MainMenu";
    private int score;
    public GameObject scoreTextObject;
    private bool gameOver;

    // Start is called before the first frame update
    void Start (){
        string thisLevel = SceneManager.GetActiveScene().name;
        gameOver = false;
        score = 0;
        if ((thisLevel != "SceneLose") && (thisLevel != "SceneWin")){
            SceneDied = thisLevel;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) {
            QuitGame();
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("Level1");
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

    public void AddScore (int newScoreValue) {
        score += newScoreValue;
        UpdateScore ();
        if (score >= 20 && !gameOver) {
            gameOver = true;
            SceneManager.LoadScene("SceneWin");
        }
    }

    void UpdateScore () {
        Text scoreTextB = scoreTextObject.GetComponent<Text>();
        scoreTextB.text = "" + score;
    }
}
