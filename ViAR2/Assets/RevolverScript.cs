using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetButton("Jump") || Input.GetButton("Fire2") || Input.GetButton("Fire3"))
        {
            Debug.Log("pressed");
        }
    }

    public void Shoot()
    {
        
    }
}
