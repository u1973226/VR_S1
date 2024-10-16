using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverScript : MonoBehaviour
{
    Vector3 origin;
    GameObject magnetParent;
    public float magnetSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetButton("Jump") || Input.GetButton("Fire2") || Input.GetButton("Fire3"))
        {
            Debug.Log("pressed");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn") {
            transform.position = origin;
        }
    }

    public void Shoot()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        var hit RaycastHit;

        if (Physics.Raycast(transform.position, fwd, hit, 100)) {
            if (hit.transform.gameObject.tag == "Target") Destroy(hit.transform.gameObject);
        }
    }

    public void SetMagnet(GameObject magnet)
    {
        magnetParent = magnet;
    }

    public void Attract() 
    {
        var delta = magnetParent.transform.position - transform.position;
        transform.position += delta * Time.deltaTime * magnetSpeed;
    }
}
