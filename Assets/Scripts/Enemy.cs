using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int pointAmount = 15;
    [SerializeField] int hitPoint = 3;
    GameObject parentGameObject;
    ScoreBoard scoreBoard;

     void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.angularDrag = 0;
    }

    void OnParticleCollision(GameObject other)
    {
        hitPoint--;
        HitEnemy();
        if(hitPoint < 1)
        {
           KillEnemy(other);
        }

    }

    private void HitEnemy()
    {
        GameObject hitVfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hitVfx.transform.parent = parentGameObject.transform;
        //Destroy(gameObject);
    }
    private void KillEnemy(GameObject other)
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
        scoreBoard.IncreaseScore(pointAmount);
    }

}
