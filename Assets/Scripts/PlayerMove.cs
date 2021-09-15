using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public GameObject Meteorito;
    public float tiempoMeteorito;
    private float nuevoMeteorito;

    public GameObject initBala;
    public GameObject BalaPrefab;
    public float VelBala;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nuevoMeteorito <= 0)
        {
            nuevoMeteorito = tiempoMeteorito;
            int meteoritoPos = Random.Range(-13, 14);
            GameObject MeteoritoTemp = Instantiate(Meteorito, new Vector3(meteoritoPos, 20, 0), Quaternion.identity);
            Destroy(MeteoritoTemp, 5);
        }
        nuevoMeteorito -= Time.deltaTime;


        if (Input.GetKey("d"))
        {
            rb.velocity = transform.right * 5;
        }

        if (Input.GetKey("a"))
        {
            rb.velocity = -transform.right * 5;
        }

        if (Input.GetKey("w"))
        {
            rb.velocity = transform.up * 5;
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = -transform.up * 5;
        }


        if (Input.GetMouseButtonDown(0))
        {
            GameObject tempBala = Instantiate(BalaPrefab, initBala.transform.position, initBala.transform.rotation);
            Rigidbody TempRB = tempBala.GetComponent<Rigidbody>();
            TempRB.AddForce(transform.up * VelBala);

            Destroy(tempBala, 5.0f);
        }
    }
}
