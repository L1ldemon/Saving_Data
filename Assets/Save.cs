using UnityEngine;
using System.Collections.Generic;

public class Save : MonoBehaviour
{
    public Inventory inventory = new Inventory();

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SaveToJson();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
        }
    }

    public void SaveToJson()
    {
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("Sauvegarde effect");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);

        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        Debug.Log("Chargement effect");
    }
}


[System.Serializable]
public class Inventory
{
    public int goldCoins;
    public bool isFull;
    public List<Items> items = new List<Items>();
}

[System.Serializable]
public class Items
{
    public string name;
    public string desc;
}