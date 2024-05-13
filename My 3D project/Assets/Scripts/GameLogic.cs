using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Slot slot1, slot2;
    public GameObject gameOverPanel, gameWinPanel;   
    public Text scoreText;
    private int score = 0;
    public Button remuseButton;
    public Stopwatch stopwatch;
    public Item[] listItem;
    private void OnValidate()
    {
        AddItemID();
    }
    private void Start()
    {
        SpawnItem();
        SpawnItem();
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Item") == null)
        {
            GameWin();
        }
        if (slot1.item != null && slot2.item != null && slot1.item.id == slot2.item.id)
        {
            Item replaceItem = Instantiate(slot1.item, new Vector3(-0.1f, 0.22f, -4.22f), slot1.item.transform.rotation);
            replaceItem.GetComponent<MeshCollider>().enabled = false;
            replaceItem.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(replaceItem.gameObject,0.5f);
            DestroyObject(slot1);
            DestroyObject(slot2);
            score++;
            scoreText.text = score.ToString();
        }     
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        DeactivateDragDrop();
    }
    public void GameWin()
    {
        gameWinPanel.SetActive(true);
        DeactivateDragDrop();
        stopwatch.isStop = true;
    }
    private void DestroyObject(Slot slot)
    {
        Destroy(slot.item.gameObject);
        slot.isOccupied = false;
        slot.item = null;        
    }
    [ContextMenu("Add Item ID")]
    public void AddItemID()
    {
        for(int i=0; i<listItem.Length; i++)
        {
            if (listItem[i] != null)
            {
                listItem[i].id = i + 1;
            }           
        }
    }
    [ContextMenu("Spawn Item")]
    public void SpawnItem()
    {
        for(int i=0; i < listItem.Length; i++)
        {
            Instantiate(listItem[i], new Vector3(Random.Range(-6,6),Random.Range(0.5f,2.5f),Random.Range(-0.3f,3f)), Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)));
        }
    }
    public void Pause()
    {
        remuseButton.gameObject.SetActive(true);
        DeactivateDragDrop();
        Time.timeScale = 0;
    }
    public void Remuse()
    {
        remuseButton.gameObject.SetActive(false);
        ActivateDragDrop();
        Time.timeScale = 1;
    }
    public void DeactivateDragDrop()
    {
        GameObject[] listObject = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < listObject.Length; i++)
        {
            listObject[i].gameObject.layer = 2;
        }
    }
    public void ActivateDragDrop()
    {
        GameObject[] listObject = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < listObject.Length; i++)
        {
            listObject[i].gameObject.layer = 6;
        }
    }
    
}
