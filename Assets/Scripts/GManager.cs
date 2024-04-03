using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print(MovingCube.currentCube.name);
            MovingCube.currentCube.Stop();
        }
    }
}
