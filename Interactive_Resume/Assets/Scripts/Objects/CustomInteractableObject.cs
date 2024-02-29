using UnityEngine;

public class CustomInteractableObject : InteractableObject
{
    protected override void OnActivate()
    {
        base.OnActivate();
        gameObject.SetActive(false);
        // Ajoutez ici le code pour activer l'objet
    }

    protected override void OnDeactivate()
    {
        base.OnDeactivate();
        gameObject.SetActive(true);
        
        // Ajoutez ici le code pour désactiver l'objet
    }
}