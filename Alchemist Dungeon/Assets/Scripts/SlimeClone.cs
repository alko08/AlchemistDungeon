using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeClone : MonoBehaviour
{
    public Transform movePoint;
    public LayerMask wall;
    private Vector3 direction;
    private Vector3 home;
    private bool canMove;
    private int bounce;
    private MoveAnim player;
    private GameInventory inventory;
    public PickUpBoss one, two, three, four, five, six;
    
    void Start() {
        home = this.transform.position;
        direction = movePoint.position - home;
        canMove = true;
        bounce = 0;
        player = GameObject.FindWithTag("PlayerController").GetComponent<MoveAnim>();
        inventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
    }
    // Update is called once per frame
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, 
            movePoint.position, 5 * Time.deltaTime);

        if (Physics2D.OverlapCircle(transform.position, 0f, wall)) {
            bounce++;
            movePoint.position = home;
        }

        if (Vector3.Distance(transform.position, home) <= .05f && bounce > 0) {
            shrink();
        } else if (canMove && Vector3.Distance(transform.position, movePoint.position) <= .05f) {
            movePoint.position += direction;
        }
    }

    public void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Player"){
            FindObjectOfType<AudioManager>().Play("Squish");
            GetComponent<Collider2D>().enabled = false;
            player.spin();
            if (inventory.item1bool) {
                inventory.InventoryRemove("item1");
                one.enableArt();
            } else if (inventory.item2bool) {
                inventory.InventoryRemove("item2");
                two.enableArt();
            } else if (inventory.item3bool) {
                inventory.InventoryRemove("item3");
                three.enableArt();
            } else if (inventory.item4bool) {
                inventory.InventoryRemove("item4");
                four.enableArt();
            } else if (inventory.item5bool) {
                inventory.InventoryRemove("item5");
                five.enableArt();
            } else if (inventory.item6bool) {
                inventory.InventoryRemove("item6");
                six.enableArt();
            }
            shrink();
        }
    }

    private void shrink() {
        canMove = false;
        movePoint.position = transform.position;
        Destroy(this.transform.parent.gameObject);
    }
}
