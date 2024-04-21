using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 offset;
    /*private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }*/
    private void OnMouseDrag()
    {
        transform.position = new Vector3(MouseWorldPosition().x,0.75f,MouseWorldPosition().z);
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
        if (hit.collider.CompareTag("Plane"))
        {
            transform.position = hit.transform.position;
            Debug.Log("Plane");
        }
    }
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        RaycastHit hit;
        Physics.Raycast(transform.position, worldMousePosFar - transform.position, out hit);
        return hit;
    }
}
