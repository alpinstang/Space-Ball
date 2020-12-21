using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionHandler : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Collision!");
    }
}
