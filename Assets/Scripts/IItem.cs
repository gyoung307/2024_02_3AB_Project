using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    string Name { get; }
    int ID { get; }
    void Use();
}

// Update is called once per frame
public class Weapon : IItem
{
    public string Name { get; set; }
    public int ID { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, int id, int damage)
    {
        Name = name;
        ID = id;
        Damage = damage;
    }
    public void Use()
    {
        Debug.Log($"Using wepon {Name} with damage {Damage} ");
    }

    public class HealthPotion : IItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int HealAmount { get; set; }

        public HealthPotion(string name, int iD, int healAmount)
        {
            Name = name;
            ID = iD;
            HealAmount = healAmount;
        }

        public void Use()
        {
            Debug.Log($"Using potion {Name} Healing for {HealAmount}");
        }

        //제너릭 인벤토리 클래스
        public class Inventory<T> where T : IItem
        {
            public List<T> items = new List<T>();

            public void AddItem(T item)
            {
                items.Add(item);
                Debug.Log($"Added {item.Name} to Inventory");
            }

            public void UseItem(int index)
            {
                if (index >= 0 && index < items.Count)
                {
                    items[index].Use();
                }
                else
                {
                    Debug.Log("Invalid item index");
                }
            }

            public void Listitems()
            {
                foreach (var item in items)
                {
                    Debug.Log($"Item: {item.Name}, ID : {item.ID}");
                }
            }
        }
    }
}
