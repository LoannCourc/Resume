using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSecondPlayer : MonoBehaviour
{
     public float moveSpeed = 5f;

    void Update()
    {
        // G�rer les mouvements du joueur
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // G�rer l'interaction avec les produits et les pointures
        if (other.CompareTag("Product"))
        {
            Product product = other.GetComponent<Product>();
            // G�rer la s�lection du produit
            Debug.Log("Vous avez s�lectionn� : " + product.productName);
        }
        else if (other.CompareTag("Size"))
        {
            Size size = other.GetComponent<Size>();
            // G�rer la s�lection de la pointure
            Debug.Log("Vous avez s�lectionn� la pointure : " + size.size);
        }
    }
}
