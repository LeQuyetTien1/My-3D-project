using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public LayerMask layerMask;
    private Vector3 slot1Pos = new Vector3(-1.09f, 0.21f, -4f);
    private Vector3 slot2Pos = new Vector3(0.91f, 0.21f, -4f);
    private Slot slot1, slot2;
    private Item dragItem;
    private void Start()
    {
        slot1 = GameObject.FindGameObjectWithTag("Slot1").GetComponent<Slot>();
        slot2 = GameObject.FindGameObjectWithTag("Slot2").GetComponent<Slot>();
        dragItem = GetComponent<Item>();
    }
    private void OnMouseDrag()
    {
        transform.position = new Vector3(MouseWorldPosition().x,0.75f,MouseWorldPosition().z);
        transform.eulerAngles = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
    private Vector3 MouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void OnMouseUp()
    {
        RaycastHit hit = CastRay();
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        if (hit.collider.CompareTag("Plane"))
        {
            if (slot1.isOccupied == false)
            {
                FitSlot(slot1Pos);
            }
            else if (slot2.isOccupied == false)
            {
                if(slot1.item.id == dragItem.id)
                {
                    FitSlot(slot2Pos);
                }
                else
                {
                    transform.position = Vector3.up;
                }
            }
        }
    }
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(transform.position, worldMousePosFar - transform.position, out hit, layerMask);
        return hit;
    }
    private void FitSlot(Vector3 slotPos)
    {
        RaycastHit hit = CastRay();
        transform.position = slotPos;
        transform.eulerAngles = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
