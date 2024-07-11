using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Cube> cubes)
    {
        foreach (Cube explodableObject in cubes)
        {
             explodableObject.Rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}