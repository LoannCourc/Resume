using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSecondPlayer : MonoBehaviour
{
     public float moveSpeed = 5f;

    void Update()
    {
        // Gérer les mouvements du joueur
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Gérer l'interaction avec les produits et les pointures
        if (other.CompareTag("Product"))
        {
            Product product = other.GetComponent<Product>();
            // Gérer la sélection du produit
            Debug.Log("Vous avez sélectionné : " + product.productName);
        }
        else if (other.CompareTag("Size"))
        {
            Size size = other.GetComponent<Size>();
            // Gérer la sélection de la pointure
            Debug.Log("Vous avez sélectionné la pointure : " + size.size);
        }
    }
}
