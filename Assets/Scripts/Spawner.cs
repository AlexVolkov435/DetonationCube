using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Cube> CreateCubes(Cube cube)
    {
        int startValues = 2;
        int finishValues = 7;
        int randomValues = Random.Range(startValues, finishValues);

        List<Cube> cubes = new List<Cube>();

        for (int i = 0; i < randomValues; i++)
        {
            var currentGameObject = Instantiate(cube, Random.insideUnitSphere.normalized + transform.position, transform.rotation);
            cubes.Add(currentGameObject);
        }

        return cubes;
    }
}
