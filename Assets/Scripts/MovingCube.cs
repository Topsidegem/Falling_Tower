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


    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}
