using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public static MovingCube currentCube { get; private set; }
    public static MovingCube lastCube { get; private set; }

    [SerializeField] private float moveSpeed = 1;

    private void OnEnable()
    {
        if(lastCube == null)
        {
            lastCube = GameObject.Find("Start").GetComponent<MovingCube>();
        }
        currentCube = this;
    }

    //private void OnEnable()
    //{
    //    if (lastCube == null)
    //    {
    //        lastCube = GameObject.Find("Start")?.GetComponent<MovingCube>();

    //        // Verificar si no se encontró el GameObject "Start"
    //        if (lastCube == null)
    //        {
    //            Debug.LogError("No se pudo encontrar el GameObject 'Start' o el componente MovingCube en él.");
    //            return;
    //        }
    //    }
    //    currentCube = this;
    //}

    internal void Stop()
    {
        moveSpeed = 0;
        float hangover = transform.position.z - lastCube.transform.position.z;  

        SplitCubeOnZ(hangover);
    }

    private void SplitCubeOnZ(float hangover)
    {
        float newZSize = lastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZSize;

        float newZPosition = lastCube.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        float cubeEdge = transform.position.z + (newZSize / 2);
        float fallingBlockZPosition = cubeEdge + fallingBlockSize / 2f;
        SpawnDropCube(fallingBlockZPosition, fallingBlockSize);
    }

    private void SpawnDropCube(float fallingBlockZPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockZPosition);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}
