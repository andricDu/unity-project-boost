using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;


    // Start is called before the first frame update
    void Start()
    {
        this.startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        const float tau = Mathf.PI * 2;
        float cycles = Time.time / period;

        movementFactor = (Mathf.Sin(cycles * tau) + 1f) / 2f ;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
