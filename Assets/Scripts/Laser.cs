using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }


    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
