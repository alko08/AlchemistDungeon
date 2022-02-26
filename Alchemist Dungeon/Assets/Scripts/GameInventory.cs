using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {

      //5 Inventory Items:
      public GameObject InventoryMenu;

      public static bool item1bool = false;
    //   public static bool item2bool = false;
    //   public static bool item3bool = false;
    //   public static bool item4bool = false;
    //   public static bool item5bool = false;
      // public static int coins = 0;

      public GameObject item1image;
    //   public GameObject item2image;
    //   public GameObject item3image;
    //   public GameObject item4image;
    //   public GameObject item5image;
    //   public GameObject coinText;

      void Start(){
            InventoryMenu.SetActive(true);
            item1image.SetActive(false);
            // item2image.SetActive(false);
            // item3image.SetActive(false);
            // item4image.SetActive(false);
            // item5image.SetActive(false);
            InventoryDisplay();
      }

      void InventoryDisplay(){
            if (item1bool == true) {item1image.SetActive(true);} else {item1image.SetActive(false);}
            // if (item2bool == true) {item2image.SetActive(true);} else {item2image.SetActive(false);}
            // if (item3bool == true) {item3image.SetActive(true);} else {item3image.SetActive(false);}
            // if (item4bool == true) {item4image.SetActive(true);} else {item4image.SetActive(false);}
            // if (item5bool == true) {item5image.SetActive(true);} else {item5image.SetActive(false);}

            // Text coinTextB = coinText.GetComponent<Text>();
            // coinTextB.text = ("COINS: " + coins);
      }

      public void InventoryAdd(string item){
            string foundItemName = item;
            if (foundItemName == "honeycomb_item") {item1bool = true;}
            // else if (foundItemName == "item2") {item2bool = true;}
            // else if (foundItemName == "item3") {item3bool = true;}
            // else if (foundItemName == "item4") {item4bool = true;}
            // else if (foundItemName == "item5") {item5bool = true;}
            InventoryDisplay();
      }

      public void InventoryRemove(string item){
            string itemRemove = item;
            if (itemRemove == "honeycomb_item") {item1bool =false;}
            // else if (itemRemove == "item2") {item2bool =false;}
            // else if (itemRemove == "item3") {item3bool =false;}
            // else if (itemRemove == "item4") {item4bool =false;}
            // else if (itemRemove == "item5") {item5bool =false;}
            InventoryDisplay();
      }

    //   public void CoinChange(int amount){
    //         coins +=amount;
    //         InventoryDisplay();
    //   }
}