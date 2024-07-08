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
        Spawn();
    }

    private void Spawn()
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
                currentGameObject = Instantiate(_object, new Vector3(GenarationRandomValueX(), GenarationRandomValueY(), GenarationRandomValueZ()), Quaternion.identity);
                ObjectÑhanges(currentGameObject);
            }
        }
        else
        {
            ExplodeChangen?.Invoke(currentGameObject);
            Destroy(gameObject);
        }
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

    private void ObjectÑhanges(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);
        gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));

        _maximumProbability /= 2;

        Debug.Log(_maximumProbability);
    }
}
