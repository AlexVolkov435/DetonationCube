using System;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    private int _maximumProbability = 100;

    public event Action<GameObject> ExplodeChangen;

    GameObject currentGameObject;

    private void OnMouseUpAsButton()
    {
        int startValues = 2;
        int finishValues = 7;

        int randomValues = UnityEngine.Random.Range(startValues, finishValues);

        for (int i = 0; i < randomValues; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        int startValues = 0;
        int finishValues = 101;

        int randomValuesProbability = UnityEngine.Random.Range(startValues, finishValues);

        if (randomValuesProbability <= _maximumProbability)
        {
            currentGameObject = Instantiate(_object, new Vector3(transform.position.x + UnityEngine.Random.Range(-5f, 5f), transform.position.y - UnityEngine.Random.Range(-3f, -5f), transform.position.z + UnityEngine.Random.Range(-5f, 5f)), Quaternion.identity);

            ObjectÑhanges(currentGameObject);
        }
        else
        {
            ExplodeChangen?.Invoke(currentGameObject);
            Destroy(gameObject);
        }
    }

    private void ObjectÑhanges(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);
        gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));

        _maximumProbability /= 2;

        Debug.Log(_maximumProbability);
    }
}
