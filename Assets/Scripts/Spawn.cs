using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private GameObject _object;

    public event Action <List<Rigidbody>> ExplodeChangen;

    private int _maximumProbability = 100;

    List<Rigidbody> cubes = new List<Rigidbody>();

    private void OnEnable()
    {
        _cube.SpawnChangen += CreateCube;
    }

    private void OnDisable()
    {
        _cube.SpawnChangen -= CreateCube;
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
                cubes.Add(Init().GetComponent<Rigidbody>());
                _maximumProbability /= 2;
            }
        }
        else
        {
            ExplodeChangen?.Invoke(cubes);
            Destroy(gameObject);
        }
    }
 
    private GameObject Init()
    {
        var currentGameObject = Instantiate(_object, new Vector3(GenarationRandomValueX(),
        GenarationRandomValueY(), GenarationRandomValueZ()), Quaternion.identity);

        _cube.Object—hanges(currentGameObject);

        return currentGameObject;
    }    

    private float GenarationRandomValueX()
    {
        return transform.position.x + UnityEngine.Random.Range(-5f, 5f);
    }

    private float GenarationRandomValueY()
    {
        return transform.position.y - UnityEngine.Random.Range(-3f, -5f);
    }

    private float GenarationRandomValueZ()
    {
        return transform.position.z + UnityEngine.Random.Range(-5f, 5f);
    }
}
