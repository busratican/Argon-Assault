using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionVFX;
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] GameObject[] components;
    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }
    void StartCrashSequence()
    {
        explosionVFX.Play();
        GetComponent<PlayerController>().enabled = false;
        foreach(GameObject gb in components)
        {
            gb.GetComponent<MeshRenderer>().enabled = false;
        }
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", reloadDelay);
    }

    void ReloadLevel()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentBuildIndex);
    }
}
