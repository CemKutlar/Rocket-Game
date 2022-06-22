using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapperRotator : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float slapperRotateAmount = 5000f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float turn = Input.GetAxis("Vertical");
        rb.AddRelativeTorque(Vector3.back * slapperRotateAmount * Time.deltaTime);
    }
}
