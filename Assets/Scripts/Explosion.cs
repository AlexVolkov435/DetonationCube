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

    public void ExplodeAllArea()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (var cube in overlappedColliders)

            if (cube.attachedRigidbody != null)
                cubes.Add(cube.attachedRigidbody);

        return cubes;
    }
}