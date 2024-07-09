using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _objectSpawn;

    private int _maximumProbability = 100;

    private List<Rigidbody> _cubes = new List<Rigidbody>();

    public event Action<List<Rigidbody>> ExplodeChangen;
    public event Action<GameObject> ObjectChangen;

    private void OnMouseUpAsButton()
    {
        CreateCube();
    }

    private void CreateCube()
    {
        int startValueProbability = 0;
        int finishValueProbability = 101;

        int startValues = 2;
        int finishValues = 7;

        int randomValues = UnityEngine.Random.Range(startValues, finishValues);
        int randomValuesProbability = UnityEngine.Random.Range(startValueProbability, finishValueProbability);

        if (randomValuesProbability <= _maximumProbability)
        {
            for (int i = 0; i < randomValues; i++)
            {
                _cubes.Add(Init().GetComponent<Rigidbody>());
                _maximumProbability /= 2;
            }
        }
        else
        {
            ExplodeChangen?.Invoke(_cubes);
            Destroy(gameObject);
        }
    }

    private GameObject Init()
    {
        var currentGameObject = Instantiate(_objectSpawn, new Vector3(GenarationRandomValueX(),
        GenarationRandomValueY(), GenarationRandomValueZ()), Quaternion.identity);

        ObjectChangen?.Invoke(currentGameObject);
        
        return currentGameObject;
    }

    private float GenarationRandomValueX()
    {
        float minValue = -5f;
        float maxValue = 5f;

        return transform.position.x + UnityEngine.Random.Range(minValue, maxValue);
    }

    private float GenarationRandomValueY()
    {
        float minValue = -3f;
        float maxValue = -5f;

        return transform.position.y - UnityEngine.Random.Range(minValue, maxValue);
    }

    private float GenarationRandomValueZ()
    {
        float minValue = 3f;
        float maxValue = 5f;

        return transform.position.z + UnityEngine.Random.Range(minValue, maxValue);
    }
}