using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Slot slot1, slot2;
    public GameObject gameOverPanel;
    public Item[] listItem;
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    private void Update()
    {
        if (slot1.item != null && slot2.item != null)
        {
            Debug.Log("both slot 1 and slot 2 are not null");
            if(slot1.item.GetComponent<Item>().id == slot2.item.GetComponent<Item>().id)
            {
                DestroyObject(slot1);
                DestroyObject(slot2);
            }
        }     
    }
    private void DestroyObject(Slot slot)
    {
        Debug.Log("DestroyObject: " + slot.item.GetComponent<Item>().id);
        Destroy(slot.item.gameObject);
        slot.isOccupied = false;
        slot.item = null;
    }
    [ContextMenu("Add Item ID")]
    public void AddItemID()
    {
        for(int i=0; i<listItem.Length; i++)
        {
            listItem[i].id = i + 1;
        }
    }
}
