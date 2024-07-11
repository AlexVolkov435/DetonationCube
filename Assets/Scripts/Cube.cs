using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private Rigidbody _objectSpawn;

    [SerializeField] private int _maximumProbability = 100;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

    public Rigidbody Rigidbody => _objectSpawn;

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f),
           Random.Range(0, 1f), Random.Range(0, 1f));
    }

    private void OnMouseUpAsButton()
    {
        int halvingReduction = 2;
        int startValueProbability = 0;
        int finishValueProbability = 101;
        float scaleReduction = 0.5f;

        int randomValuesProbability = Random.Range(startValueProbability, finishValueProbability);

        if (randomValuesProbability <= _maximumProbability)
        {
            _maximumProbability /= halvingReduction;
            transform.localScale *= scaleReduction;
            _explosion.Explode(_spawner.CreateCubes(this));
        }

        Destroy(gameObject);
    }
}