using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change_position() 
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 30f , gameObject.transform.position.z);
    }
}
