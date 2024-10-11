using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;
using static Weapon.HealthPotion;


public class InventoryManager : MonoBehaviour
{
    private Inventory<IItem> playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = new Inventory<IItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q)) playerInventory.AddItem(new Weapon("Sword", 1, 10));
        if (Input.GetKeyUp(KeyCode.W)) playerInventory.AddItem(new HealthPotion("Potion", 1, 10));
        if (Input.GetKeyUp(KeyCode.Space)) playerInventory.Listitems();
        if (Input.GetKeyUp(KeyCode.Alpha1)) playerInventory.UseItem(0);
        if (Input.GetKeyUp(KeyCode.Alpha2)) playerInventory.UseItem(1);
    }
}
