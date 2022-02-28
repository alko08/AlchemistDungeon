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
        }
        
    }

    private void Hide() {
        text.SetActive(false);
        background.SetActive(false);
    }

    private void Show() {
        text.SetActive(true);
        background.SetActive(true);
    }

    IEnumerator Tutorial0Coroutine() {
        yield return new WaitForSeconds(1f);
        Show();
        Setup("Home sweet home.");
        yield return new WaitForSeconds(3f);
        Setup("To move press WASD or the Arrow Keys.");
        yield return new WaitUntil(() => (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f || Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f));
        Destroy(gameObject, 3f);
    }

    IEnumerator Tutorial1Coroutine() {
        yield return new WaitForSeconds(1f);
        Show();
        Setup("OH NO! THE SLIMES GOT LOOSE AGAIN!");
        yield return new WaitForSeconds(3.5f);
        Setup("Be careful of the slippery slime!");
        Destroy(gameObject, 5f);
    }

    IEnumerator Tutorial2Coroutine() {
        yield return new WaitForSeconds(1f);
        Show();
        Setup("I got to make a potion to clean up this mess...");
        yield return new WaitForSeconds(3f);
        Setup("Collect every ingredient and then use the cauldron.");
        Destroy(gameObject, 5f);
    }

    private void Setup(string text) {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        
        Vector2 padding = new Vector2(.5f,.5f);
        backgroundSpriteRenderer.size = textSize + padding;

        Vector3 offset = new Vector3(-.8f, 0f);
        backgroundSpriteRenderer.transform.localPosition = 
        new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f) + offset;
    }
}