using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isActive = false;

    public virtual void Interact()
    {
        isActive = !isActive;

        if (isActive)
        {
            OnActivate();
        }
        else
        {
            OnDeactivate();
        }
    }

    protected virtual void OnActivate()
    {
        Debug.Log("Activated: " + gameObject.name);
        
    }

    protected virtual void OnDeactivate()
    {
        Debug.Log("Deactivated: " + gameObject.name);
        
    }
}
