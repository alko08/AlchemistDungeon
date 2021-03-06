using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public static string SceneDied = "MainMenu";
    // private int score;
    // public GameObject scoreTextObject;
    // private bool gameOver;
    public static bool GameisPaused = false;
    private GameObject pauseMenuUI;
    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;
    private Slider sliderVolumeCtrl;

    // Start is called before the first frame update
    void Start (){
        pauseMenuUI = GameObject.FindWithTag("PauseMenu");
        pauseMenuUI.SetActive(false);
        string thisLevel = SceneManager.GetActiveScene().name;
        // gameOver = false;
        // score = 0;
        if ((thisLevel != "SceneLose") && (thisLevel != "SceneWin")){
            SceneDied = thisLevel;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameisPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    // void Awake (){
    //     SetLevel (volumeLevel);
    //     GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
    //     if (sliderTemp != null){
    //         sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
    //         sliderVolumeCtrl.value = volumeLevel;
    //     }
    // }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    // public void SetLevel (float sliderValue){
    //     mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
    //     volumeLevel = sliderValue;
    //     // Debug.Log(volumeLevel);
    // }

    public void StartGame() {
        SceneManager.LoadScene("Tutorial0");
    }

    public void RestartGame() {
        Time.timeScale = 1f;
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

    public void LevelSelect (){
        SceneManager.LoadScene("LevelSelect");
    }

    public void PlayLevel1() {
        SceneManager.LoadScene("Tutorial2");
    }
    public void PlayLevel2() {
        SceneManager.LoadScene("Tutorial2.5");
    }
    public void PlayLevel3() {
        SceneManager.LoadScene("Level1");
    }
    public void PlayLevel4() {
        SceneManager.LoadScene("Level2");
    }
    public void PlayLevel5() {
        SceneManager.LoadScene("Level3");
    }
    public void PlayLevel6() {
        SceneManager.LoadScene("Tutorial3.5");
    }
    public void PlayLevel7() {
        SceneManager.LoadScene("Tutorial4");
    }
    public void PlayLevel8() {
        SceneManager.LoadScene("holes_and_switches");
    }
    public void PlayLevel9() {
        SceneManager.LoadScene("BossFight0");
    }

    // public void AddScore (int newScoreValue) {
    //     score += newScoreValue;
    //     UpdateScore ();
    //     if (score >= 20 && !gameOver) {
    //         gameOver = true;
    //         SceneManager.LoadScene("SceneWin");
    //     }
    // }

    // void UpdateScore () {
    //     Text scoreTextB = scoreTextObject.GetComponent<Text>();
    //     scoreTextB.text = "" + score;
    // }
}
