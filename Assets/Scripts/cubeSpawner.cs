using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSpawner : MonoBehaviour
{
    [SerializeField] private MovingCube cubePrefab;
    [SerializeField] private GameObject spawner; 

    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);

        if (MovingCube.lastCube != null && MovingCube.lastCube.gameObject != GameObject.Find("Start"))
        {
            float newYPosition = MovingCube.lastCube.transform.position.y + cubePrefab.transform.localScale.y;

            cube.transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

            spawner.transform.position = new Vector3(spawner.transform.position.x, newYPosition, spawner.transform.position.z);
        }
        else
        {
            cube.transform.position = transform.position;
        }
    }
}
