using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTool : MonoBehaviour
{
    public Transform toolTip;
    public float toolRange = 10.0f;
    public LayerMask interactableLayers;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        FollowMouse();
        HandleInput();
    }

    void FollowMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 targetPoint = ray.GetPoint(rayDistance);
            toolTip.LookAt(targetPoint);
        }
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, toolRange, interactableLayers))
            {
                InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
                if (interactableObject != null)
                {
                    interactableObject.Interact();
                }
            }
        }
    }
}
