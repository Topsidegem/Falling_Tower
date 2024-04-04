using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(MovingCube.currentCube != null)
            {
                print(MovingCube.currentCube.name);
                MovingCube.currentCube.Stop();
            }
            
            FindObjectOfType<cubeSpawner>().SpawnCube();
        }
    }
}
