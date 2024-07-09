using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Spawn _spawn;

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnEnable()
    {
        _spawn.ExplodeChangen += Explode;
    }

    private void OnDisable()
    {
        _spawn.ExplodeChangen -= Explode;
    }

    private void Explode(List<Rigidbody> cubes)
    {
        foreach (Rigidbody explodableObject in cubes)
        {
            if (explodableObject)
            {
                explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}