using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MovingCube.currentCube.Stop();
        }
    }
}
