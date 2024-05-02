using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isOccupied = false;
    public GameObject item;
    private void OnTriggerStay(Collider other)
    {
        isOccupied = true;
        /*item=other.GetComponent<Item>();*/
        item=other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        isOccupied = false;
        item = null;
    }
}
