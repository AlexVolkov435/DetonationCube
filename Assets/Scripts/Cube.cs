using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action SpawnChangen;

    private void OnMouseUpAsButton()
    {
        SpawnChangen?.Invoke();
    }

    public void Object—hanges(GameObject cube)
    {
        cube.transform.localScale *= 0.5f;
        cube.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0, 1f),
           UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }
}
