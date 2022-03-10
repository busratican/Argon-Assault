using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
         
    void OnCollisionEnter(Collision collision)
    {
        Invoke("ReloadLevel", reloadDelay);
    }

    void OnTriggerEnter(Collider other)
    {
         Invoke("ReloadLevel", reloadDelay);
    }

    void ReloadLevel()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentBuildIndex);
    }
}
