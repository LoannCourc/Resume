using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public float spawnInterval = 1.5f;
    public float spawnBottomY = -5f;
    public float spawnForceMin = 5f;
    public float spawnForceMax = 15f;

    public float scaleMin = 1f;
    public float scaleMax = 2.5f;

    private float timer;
    private bool gameIsOver = false;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Update()
    {
        if (!gameIsOver)
        {
            timer += Time.deltaTime;
            if (timer > spawnInterval)
            {
                SpawnObject();
                timer -= spawnInterval;
            }
        }
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnObjects.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), spawnBottomY, 0);

        GameObject spawnedObject = Instantiate(spawnObjects[randomIndex], spawnPosition, Quaternion.identity);

        // Ajoute un scale aléatoire à l'objet
        float randomScale = Random.Range(scaleMin, scaleMax);
        spawnedObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        // Ajoute une force vers le haut avec une valeur aléatoire
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float randomForce = Random.Range(spawnForceMin, spawnForceMax);
            Vector3 force = Vector3.up * randomForce;
            rb.AddForce(force, ForceMode.Impulse);
        }

        // Ajoute l'objet à la liste des objets instanciés
        spawnedObjects.Add(spawnedObject);
    }

    public void GameOver()
    {
        // Supprime tous les objets instanciés
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        // Vide la liste des objets instanciés
        spawnedObjects.Clear();
        gameIsOver = true;
    }
}