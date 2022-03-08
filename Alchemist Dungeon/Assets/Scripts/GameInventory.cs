using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {

      //6 Inventory Items:
      // public GameObject InventoryMenu;

      public bool item1bool = false;
      public bool item2bool = false;
      public bool item3bool = false;
      public bool item4bool = false;
      public bool item5bool = false;
      public bool item6bool = false;

      public static bool potion1bool = false;
      
      // public static int coins = 0;

      public GameObject item1image;
      public GameObject item2image;
      public GameObject item3image;
      public GameObject item4image;
      public GameObject item5image;
      public GameObject item6image;

      public GameObject potion1image;

      // Recipes
      public bool canCraft1;
      public bool canCraft2;
      public bool canCraft3;
      public bool canCraft4;
      public bool canCraft5;
      public int recipeNum = 1;

      // Enable Next Level
      private DoorExit door;

    //   public GameObject coinText;

      void Start(){
            item1bool = false;
            item2bool = false;
            item3bool = false;
            item4bool = false;
            item5bool = false;
            item6bool = false;
            potion1bool = false;

            // InventoryMenu.SetActive(true);
            CantCraft();
            InventoryDisplay();

            door = GameObject.FindWithTag("Door").GetComponent<DoorExit>();
      }

      void InventoryDisplay(){
            item1image.SetActive(item1bool);
            item2image.SetActive(item2bool);
            item3image.SetActive(item3bool);
            item4image.SetActive(item4bool);
            item5image.SetActive(item5bool);
            item6image.SetActive(item6bool);

            potion1image.SetActive(potion1bool);
            // Text coinTextB = coinText.GetComponent<Text>();
            // coinTextB.text = ("COINS: " + coins);
      }

      public void InventoryAdd(string item){
            string foundItemName = item;
            if (foundItemName == "item1") {item1bool = true;}
            else if (foundItemName == "item2") {item2bool = true;}
            else if (foundItemName == "item3") {item3bool = true;}
            else if (foundItemName == "item4") {item4bool = true;}
            else if (foundItemName == "item5") {item5bool = true;}
            else if (foundItemName == "item6") {item6bool = true;}
            InventoryDisplay();

            // Updating canCraft bools
            canCraft1 = item1bool && item2bool && item3bool;
            canCraft2 =canCraft1 && item4bool;
            canCraft3 = canCraft2 && item5bool;
            canCraft4 = canCraft3 && item6bool;
            canCraft5 = canCraft4 && recipeNum == 5;
      }

      public void InventoryRemove(string item){
            string itemRemove = item;
            if (itemRemove == "item1") {item1bool =false;}
            else if (itemRemove == "item2") {item2bool =false;}
            else if (itemRemove == "item3") {item3bool =false;}
            else if (itemRemove == "item4") {item4bool =false;}
            else if (itemRemove == "item5") {item5bool =false;}
            else if (itemRemove == "item6") {item5bool =false;}
            InventoryDisplay();

            // Updating canCraft bools
            canCraft1 = item1bool && item2bool && item3bool;
            canCraft2 = canCraft1 && item4bool;
            canCraft3 = canCraft2 && item5bool;
            canCraft4 = canCraft3 && item6bool;
            canCraft5 = canCraft4 && recipeNum == 5;
      }

    //   public void CoinChange(int amount){
    //         coins +=amount;
    //         InventoryDisplay();
    //   }

    private void CantCraft() {
            canCraft1 = false;
            canCraft2 = false;
            canCraft3 = false;
            canCraft4 = false;
            canCraft5 = false;
    }

    public void Craft1()
    {
            item1bool = false;
            item2bool = false;
            item3bool = false;

            item1image.SetActive(false);
            item2image.SetActive(false);
            item3image.SetActive(false);

            potion1bool = true;
            CantCraft();
            InventoryDisplay();

            door.EnableExit();
    }

    public void Craft2()
    {
            item1bool = false;
            item2bool = false;
            item3bool = false;
            item4bool = false;

            item1image.SetActive(false);
            item2image.SetActive(false);
            item3image.SetActive(false);
            item4image.SetActive(false);

            potion1bool = true;
            CantCraft();
            InventoryDisplay();

            door.EnableExit();
    }

    public void Craft3()
    {
            item1bool = false;
            item2bool = false;
            item3bool = false;
            item4bool = false;
            item5bool = false;

            item1image.SetActive(false);
            item2image.SetActive(false);
            item3image.SetActive(false);
            item4image.SetActive(false);
            item5image.SetActive(false);

            potion1bool = true;
            CantCraft();
            InventoryDisplay();

            door.EnableExit();
    }

    public void Craft4()
    {
            item1bool = false;
            item2bool = false;
            item3bool = false;
            item4bool = false;
            item5bool = false;
            item6bool = false;

            item1image.SetActive(false);
            item2image.SetActive(false);
            item3image.SetActive(false);
            item4image.SetActive(false);
            item5image.SetActive(false);
            item6image.SetActive(false);

            potion1bool = true;
            CantCraft();
            InventoryDisplay();

            door.EnableExit();
    }

    public void Craft5()
    {
            item1bool = false;
            item2bool = false;
            item3bool = false;
            item4bool = false;
            item5bool = false;
            item6bool = false;

            item1image.SetActive(false);
            item2image.SetActive(false);
            item3image.SetActive(false);
            item4image.SetActive(false);
            item5image.SetActive(false);
            item6image.SetActive(false);

            potion1bool = true;
            CantCraft();
            InventoryDisplay();

            door.ThrowPotion();
    }
}