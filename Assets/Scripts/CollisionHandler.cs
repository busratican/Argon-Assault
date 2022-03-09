using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
         
    void OnCollisionEnter(Collision collision)
    {
        Invoke("ReloadLevel", 0.1f);
    }

    void OnTriggerEnter(Collider other)
    {
         Invoke("ReloadLevel", 0.3f);
    }

    void ReloadLevel()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentBuildIndex);
    }
}
