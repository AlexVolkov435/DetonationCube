using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Object _object;

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnEnable()
    {
        _object.ExplodeChangen += Explode;
    }

    private void OnDisable()
    {
        _object.ExplodeChangen -= Explode;
    }

    private void Explode(GameObject gameObject)
    {
        foreach (Rigidbody explodableObject in GetObjects(gameObject))
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetObjects(GameObject gameObject)
    {
        if (gameObject != null)
        {
            Collider[] gameColliders = gameObject.GetComponents<Collider>();
            List<Rigidbody> cube = new List<Rigidbody>();

            foreach (var gameCollider in gameColliders)
            {
                if (gameCollider.attachedRigidbody != null)
                    cube.Add(gameCollider.attachedRigidbody);
            }
            return cube;
        }

        return null;
    }
}
