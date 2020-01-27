using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private GameObject getTarget;
    private bool isMouseDragging;
    private Vector3 offsetValue;
    private Vector3 positionOfScreen;

    void Start()
    {
        //isMouseDragging = false;
       // getTarget = null;
    }


    void Update()
    {
   
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            getTarget = ReturnClickedObject(out hitInfo);
            if(getTarget != null)
            {
                isMouseDragging = true;
                positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                offsetValue = 
                    Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z)) - getTarget.transform.position;
               // print("A");
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
            //getTarget = null;
        }

        if (isMouseDragging)
        {
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace);
            if(getTarget != null)
            getTarget.transform.position = currentPosition;
        }
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Piece")))
        {
            print("to spiti");
            target = hit.collider.gameObject;
        }
        return target;
    }
}
