using UnityEngine;
using UnityEngine.Events;

public class GenericInteractableObject : InteractableObject
{
    public UnityEvent onActivateEvent;
    public UnityEvent onDeactivateEvent;

    protected override void OnActivate()
    {
        base.OnActivate();
        onActivateEvent.Invoke();
    }

    protected override void OnDeactivate()
    {
        base.OnDeactivate();
        onDeactivateEvent.Invoke();
    }
}