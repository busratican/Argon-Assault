using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;
    [SerializeField] int pointAmount = 15;
    [SerializeField] int hitPoint = 3;

     void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
           ProcessHit();
           KillEnemy(other);
        }

    }

    private void HitEnemy()
    {
        GameObject hitVfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hitVfx.transform.parent = parent;
        //Destroy(gameObject);
    }
    private void KillEnemy(GameObject other)
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {     
        scoreBoard.IncreaseScore(pointAmount);
  
    }
}
