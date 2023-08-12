using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space!");
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left!");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right!");
        }
    }
}
