using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        GetComponent<Renderer>().material.color = GetRandomColor();

        transform.localScale = new Vector3(lastCube.transform.localScale.x, transform.localScale.y, lastCube.transform.localScale.z);
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    internal void Stop()
    {
        moveSpeed = 0;
        float hangover = transform.position.z - lastCube.transform.position.z;

        if(Mathf.Abs(hangover) >= lastCube.transform.localScale.z)
        {
            lastCube = null;
            currentCube = null;
            SceneManager.LoadScene(0);
        }

        float direction = hangover > 0 ? 1f : -1f;
        SplitCubeOnZ(hangover, direction);
    }

    private void SplitCubeOnZ(float hangover, float direction)
    {
        float newZSize = lastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZSize;

        float newZPosition = lastCube.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        float cubeEdge = transform.position.z + (newZSize / 2 * direction);
        float fallingBlockZPosition = cubeEdge + fallingBlockSize / 2f * direction;

        SpawnDropCube(fallingBlockZPosition, fallingBlockSize);
    }

    private void SpawnDropCube(float fallingBlockZPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockZPosition);

        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        Destroy(cube.gameObject, 1f);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}
