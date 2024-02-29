using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameTrigger : MonoBehaviour
{
    public TMP_Text letterText; // Référence au Texte 3D
    public string miniGameKey = "E"; // Lettre à appuyer pour lancer le mini-jeu
    public string miniGameSceneName; // Nom de la scène du mini-jeu

    private bool inTriggerZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            letterText.text = miniGameKey;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTriggerZone = false;
            letterText.text = "";
        }
    }

    private void Update()
    {
        if (inTriggerZone && Input.GetKeyDown(KeyCode.E))
        {
            LoadMiniGame();
        }
    }

    private void LoadMiniGame()
    {
        // Code pour charger la scène du mini-jeu
        SceneTransitionManager.Instance.ChangeScene(miniGameSceneName);
    }
}