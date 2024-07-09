using UnityEngine;

public class ObjectModification : MonoBehaviour
{
    [SerializeField] private Spawn _spawn;
   
    private float _scaleReduction = 0.5f;
   
    private void OnEnable()
    {
        _spawn.ObjectChangen += Object—hanges;
    }

    private void OnDisable()
    {
        _spawn.ObjectChangen -= Object—hanges;
    }

    public void Object—hanges(GameObject cube)
    {
        cube.transform.localScale *= _scaleReduction;
        cube.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f),
           Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
