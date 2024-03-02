using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public TextMeshProUGUI demandText;

    private void Start()
    {
        StartCoroutine(SpawnCustomers());
    }

    IEnumerator SpawnCustomers()
    {
        while (true)
        {
            // G�n�rer une demande al�atoire
            string demand = GenerateRandomDemand();
            // Afficher la demande
            demandText.text = "Demande : " + demand;
            yield return new WaitForSeconds(Random.Range(5f, 10f)); // Intervalle entre chaque client
        }
    }

    string GenerateRandomDemand()
    {
        // G�n�rer une demande al�atoire (par exemple, choisir un produit et une pointure al�atoirement)
        string product = GetRandomProduct();
        int size = GetRandomSize();
        return product + " - Taille : " + size;
    }

    string GetRandomProduct()
    {
        string[] products = { "Chaussures de tennis", "Chaussures de badminton", "Chaussures de squash" };
        return products[Random.Range(0, products.Length)];
    }

    int GetRandomSize()
    {
        return Random.Range(36, 45); // Pointures du 36 au 44 inclus
    }
}