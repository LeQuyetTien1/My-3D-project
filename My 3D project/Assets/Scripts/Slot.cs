using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isOccupied = false;
    /*private void Update()
    {
        bool isHit = CastRay();
        if (isHit == true)
        {
            isOccupied = true;
        }
        else
        {
            isOccupied = false;
        }
    }
    private bool CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        return Physics.Raycast(transform.position, worldMousePosNear - transform.position);
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        isOccupied = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        isOccupied = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isOccupied = false;
    }
}
