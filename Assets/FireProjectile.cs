using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public Rigidbody rb;
    public Collider col;
    public Vector3 velocity;
    public float lifetime;

    void Awake()
    {
        //rb.velocity = this.velocity;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0f)
        { 
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(this.gameObject);
    }
}
