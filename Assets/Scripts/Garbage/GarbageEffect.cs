using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEffect : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem garbageParticles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            DestroyGarbage();
        }
    }
    public void DestroyGarbage()
    {
        Instantiate(garbageParticles, transform.position, Quaternion.identity);
    }
}
