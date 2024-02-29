using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target; // Référence au joueur à suivre
    public float distance = 5.0f; // Distance entre la caméra et le joueur
    public float height = 2.0f; // Hauteur de la caméra par rapport au sol
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la caméra

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height; // Position cible de la caméra
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Position interpolée pour un suivi fluide
        transform.position = smoothedPosition; // Déplace la caméra à la position interpolée

        transform.LookAt(target.position + Vector3.up * 0.5f); // Oriente la caméra vers le joueur
    }

}