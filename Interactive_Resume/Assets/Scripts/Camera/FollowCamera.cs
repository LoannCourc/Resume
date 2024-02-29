using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target; // R�f�rence au joueur � suivre
    public float distance = 5.0f; // Distance entre la cam�ra et le joueur
    public float height = 2.0f; // Hauteur de la cam�ra par rapport au sol
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la cam�ra

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height; // Position cible de la cam�ra
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Position interpol�e pour un suivi fluide
        transform.position = smoothedPosition; // D�place la cam�ra � la position interpol�e

        transform.LookAt(target.position + Vector3.up * 0.5f); // Oriente la cam�ra vers le joueur
    }

}