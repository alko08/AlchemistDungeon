using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChatBubble : MonoBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;
    public GameObject text;
    public GameObject background;
    public GameObject EButton;
    private bool showE = true;

    private void Awake() {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Start() {
        Setup("hi");
        Hide();
        if (SceneManager.GetActiveScene().name == "Tutorial0") {
            StartCoroutine(Tutorial0Coroutine());
        } else if (SceneManager.GetActiveScene().name == "Tutorial1") {
            StartCoroutine(Tutorial1Coroutine());
        } else if (SceneManager.GetActiveScene().name == "Tutorial2") {
            StartCoroutine(Tutorial2Coroutine());
        } else if (SceneManager.GetActiveScene().name == "Tutorial2.5") {
            StartCoroutine(Tutorial3Coroutine());
        }
        
    }

    private void Hide() {
        text.SetActive(false);
        background.SetActive(false);
        EButton.SetActive(false);
    }

    private void Show() {
        text.SetActive(true);
        background.SetActive(true);
        EButton.SetActive(showE);
    }

    IEnumerator Tutorial0Coroutine() {
        yield return new WaitForSeconds(1f);
        Setup("Home sweet home.");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        // Setup("To move press WASD or the Arrow Keys.");
        // yield return new WaitForSeconds(.5f);
        // yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        Destroy(gameObject);
    }

    IEnumerator Tutorial1Coroutine() {
        
        yield return new WaitForSeconds(.5f);
        showE = false;
        Setup("OH NO! THE SLIMES GOT LOOSE AGAIN!");
        yield return new WaitForSeconds(2.8f);
        showE = true;
        Setup("OH NO! THE SLIMES GOT LOOSE AGAIN!");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        Setup("I got to follow that slime!");
        yield return new WaitForSeconds(.5f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        Destroy(gameObject);
    }

    IEnumerator Tutorial2Coroutine() {
        yield return new WaitForSeconds(.5f);
        Setup("I got to make a potion to clean up this mess...");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        Setup("Collect every ingredient and then use the cauldron!");
        yield return new WaitForSeconds(.5f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        Destroy(gameObject);
    }
    IEnumerator Tutorial3Coroutine() {
        yield return new WaitForSeconds(.5f);
        Setup("Watch out for those holes!");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        Destroy(gameObject);
    }

    private void Setup(string text) {
        Show();
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        Vector2 padding = new Vector2(.5f,.5f);
        if (showE) {
            padding = new Vector2(1.25f,.5f);
        }
        
        backgroundSpriteRenderer.size = textSize + padding;

        Vector3 offset = new Vector3(-.8f, 0f);
        backgroundSpriteRenderer.transform.localPosition = 
        new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f) + offset;
        
        offset = new Vector3(-1.4f, 0f);
        EButton.transform.localPosition =
        new Vector3(backgroundSpriteRenderer.size.x, 0f) + offset;
        
    }
}