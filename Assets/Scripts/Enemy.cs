using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{this.name} is collide {other.gameObject.name}");
        Destroy(gameObject);
    }
}
