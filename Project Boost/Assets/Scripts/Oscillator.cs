using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    //[SerializeField] bool isStartAnimation = false;
    //bool isCheatActivated = false;

    //Cheats cheats;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        //cheats = GetComponent<Cheats>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Oscilation();
    }

    private void Oscilation()
    {
        if (period >= Mathf.Epsilon)
        {
            float cycles = Time.time / period;  // continually growing over time
            //if(isStartAnimation && cycles > 1)
            //{
            //    return;
            //}
            //cheats.DeactivteCollision();
            const float tau = Mathf.PI * 2;  // constant value of 6.283
            float rawSinWave = Mathf.Sin(cycles * tau);  // going from -1 to 1

            movementFactor = (rawSinWave + 1f) / 2f;   // recalculated to go from 0 to 1 so its cleaner

            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;
        }
    }
}
