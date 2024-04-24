using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public LayerMask layerMask;
    private void OnMouseDrag()
    {
        transform.position = new Vector3(MouseWorldPosition().x,0.75f,MouseWorldPosition().z);
        transform.eulerAngles = Vector3.zero;
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
        
        if (hit.collider.CompareTag("Plane1"))
        {
            transform.position = new Vector3(-1.09f, 0.21f, -3.8f); ;
            transform.eulerAngles = new Vector3(-90, 0, 0);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Plane");
        }
        else if (hit.collider.CompareTag("Plane2"))
        {
            transform.position = new Vector3(0.91f, 0.21f, -3.8f); ;
            transform.eulerAngles = new Vector3(-90, 0, 0);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Plane");
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
}
