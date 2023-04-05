using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private float speed;
    [SerializeField] private float rangoDirection = 90f;
    [SerializeField] private float minX, maxX, minY, maxY;
    public Rigidbody2D rb;


    public void OnSpawn()
    {
        float direccion = Random.Range(-rangoDirection, rangoDirection);
        transform.rotation = Quaternion.Euler(0, 0, direccion);
        rb.velocity = transform.right * speed;
    }


    protected virtual void Update()
    {
        PositionControl();
    }


    protected virtual void DestroyAsteroid()
    {
        Gamemanager.Instance.AddPoints(points);
        gameObject.SetActive(false);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.gameObject.layer==3)
        {
            
            collision.gameObject.SetActive(false);
            DestroyAsteroid();
        }
    }


    private void PositionControl()
    {
        Vector3 currentPosition = transform.position;
        if (currentPosition.x > maxX)
        {
            currentPosition.x = minX;
        }
        else if (currentPosition.x < minX)
        {
            currentPosition.x = maxY;
        }
        if (currentPosition.y > maxY)
        {
            currentPosition.y = minY;
        }
        else if (currentPosition.y < minY)
        {
            currentPosition.y = maxY;
        }
        transform.position = currentPosition;
    }
}
