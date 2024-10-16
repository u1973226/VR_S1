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
        /*RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, hit, 100)) {
            if (hit.transform.gameObject.tag == "Target") {
                Destroy(hit.transform.gameObject);
            }
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);*/
        
        Transform shootable = gameObject.transform.GetChild(1);
        Ray ray = new Ray(shootable.position, shootable.transform.TransformDirection(Vector3.forward));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000)) {
            //LineRenderer laser;
            //laser.SetPosition(1, hit.point);
            //Debug.DrawLine(ray.origin, hit.point, Color.green, 2);
            //DrawLine(ray.origin, hit.point, Color.yellow, 2);
            if (hit.collider.tag == "Target") Destroy(hit.transform.gameObject);
        }

        //if (Physics.Raycast(ray, out hit, 100)) Debug.DrawLine(ray.origin, hit.point);
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
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
