using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeBoss : MonoBehaviour
{
    private bool happy, angryShake, surpised, fight, left, shake, centerLook,
        leftDown, leftUp, rightDown, rightUp, angry, shooting;
    public Animator anim;
    private float moveSpeed = 1f;
    public Transform movePoint;
    private Transform slimePoint;
    public GameObject slime;
    private Vector3 start;
    private MoveAnim playerScript; 
    public GameObject playerArt;
    public GameObject playerMove;
    public GameObject slimeClone;
    private GameObject clone;
    private GameObject clone2;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("PlayerController").GetComponent<MoveAnim>();
        playerScript.canMove = false;

        happy = true;
        left = true;
        rightUp = true;
        
        angryShake = false;
        surpised = false; 
        fight = false;
        shake = false;
        leftDown = false;
        leftUp = false;
        rightDown = false;
        centerLook = false;
        angry = false;
        shooting = false;


        slimePoint = slime.transform;
        start = movePoint.position;
        
        animateFunc();
        // shakes();
        StartCoroutine(AnimationCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        slimePoint.position = Vector3.MoveTowards(slimePoint.position, 
                             movePoint.position, moveSpeed * Time.deltaTime);
        if (shake) {
            // Debug.Log(Vector3.Distance(slimePoint.position, movePoint.position));
            if (Vector3.Distance(slimePoint.position, movePoint.position) <= 0f) {
                if (left) {
                    movePoint.position = start + new Vector3(.1f, 0, 0);
                    left = !left;
                } else {
                    movePoint.position = start - new Vector3(.1f, 0, 0);
                    left = !left;
                }
            }
        } else {
            movePoint.position = start;
        }

        if (fight) {
            if (playerArt.transform.position.x < this.transform.position.x - 4f) {
                if (playerArt.transform.position.y < this.transform.position.y - 2f) {
                    leftDown = true;
                    leftUp = false;
                } else {
                    leftDown = false;
                    leftUp = true;
                }
                rightDown = false;
                rightUp = false;
                centerLook = false;
            } else if (playerArt.transform.position.x > this.transform.position.x + 4f) {
                if (playerArt.transform.position.y < this.transform.position.y - 2f) {
                    rightDown = true;
                    rightUp = false;
                } else {
                    rightDown = false;
                    rightUp = true;
                }
                leftDown = false ;
                leftUp = false;
                centerLook = false;
            } else {
                leftDown = false;
                leftUp = false;
                rightDown = false;
                rightUp = false;
                centerLook = true;
            }
            animateFunc();
            if (!shooting) {
                shooting = !shooting;
                StartCoroutine(ShootCoroutine());
            }
            
        }
    }

    bool IsLeft(Vector2 A, Vector2 B)
    {
        return (-A.x * B.y + A.y * B.x) < 0;
    }

    void animateFunc() {
        // Debug.Log(surpised);
        anim.SetBool("Happy", happy);
        anim.SetBool("AngryShake", angryShake);
        anim.SetBool("Surpised", surpised);
        anim.SetBool("LeftUp", leftUp);
        anim.SetBool("LeftDown", leftDown);
        anim.SetBool("RightUp", rightUp);
        anim.SetBool("RightDown", rightDown);
        anim.SetBool("CenterDown", centerLook);
        anim.SetBool("Angry", angry);
    }

    IEnumerator AnimationCoroutine() {
        yield return new WaitForSeconds(1f);
        happy = false;
        surpised = true;
        animateFunc();
        yield return new WaitForSeconds(1f);
        happy = true;
        surpised = false;
        animateFunc();
        LeanTween.scale(slime, new Vector3(7,7,7), 5f).setOnComplete(shakes);
    }

    void shakes() {
        centerLook = true;
        rightUp = false;
        happy = false;
        surpised = false;
        angryShake = true;
        animateFunc();
        StartCoroutine(endCoroutine());
    }

    IEnumerator endCoroutine() {
        Vector3 temp2 = slimePoint.position;
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<AudioManager>().Play("ROAR");
        //
        // MORE SOUND FX 
        // FindObjectOfType<AudioManager>().Play("SlimeLaugh");
        //
        yield return new WaitForSeconds(.5f);
        shake = true;        
        yield return new WaitForSeconds(2.5f);
        shake = false;
        happy = true;
        surpised = false;
        angryShake = false;
        angry = true;
        animateFunc();
        slimePoint.position = temp2;
        yield return new WaitForSeconds(1f);
        angry = false;
        animateFunc();
        playerScript.canMove = true;
        yield return new WaitForSeconds(3f);
        fight = true;
    }

    IEnumerator ShootCoroutine() {
        Vector3 temp = playerArt.transform.position;
        FindObjectOfType<AudioManager>().Play("SlimeLaugh");
        // clone = Instantiate(slimeClone, this.transform.position, this.transform.rotation) as GameObject;
        // clone.transform.parent = null;
        // clone.SetActive(true);
        // clone.gameObject.transform.GetChild(1).position = playerArt.transform.position;

        clone2 = Instantiate(slimeClone, this.transform.position, this.transform.rotation) as GameObject;
        clone2.transform.parent = null;
        clone2.SetActive(true);
        clone2.gameObject.transform.GetChild(1).position = playerMove.transform.position;
        yield return new WaitForSeconds(Random.Range(2f, 4f));
        shooting = !shooting;
    }

    public void stop() {
        fight = false;
    }

    public void shrink() {
        fight = false;
        shake = true;
        FindObjectOfType<AudioManager>().Play("LongSquish");
        StartCoroutine(roarCoroutine());
        LeanTween.scale(gameObject, new Vector3(.143f,.143f,.143f), 4f).setOnComplete(destroyMe);
        animateFunc();
    }

    void destroyMe() {
        StartCoroutine(destroyedCoroutine());
    }

    IEnumerator destroyedCoroutine() {
        happy = true;
        shake = false;
        animateFunc();
        FindObjectOfType<AudioManager>().Play("WinSound");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SceneWin");
    }

    IEnumerator roarCoroutine() {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<AudioManager>().Play("SadRoar");
    }
}
