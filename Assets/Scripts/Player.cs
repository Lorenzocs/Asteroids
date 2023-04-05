using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private ObjectPool laserPool;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private bool isDead;


    public void Update()
    {
        if (isDead) return;
        Shoot();
    }


    void FixedUpdate()
    {
        if (isDead) return;
        Movement();
    }


    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject laser = laserPool.GetObject();
            laser.transform.position = firePoint.position;
            laser.transform.rotation = firePoint.rotation;
            laser.SetActive(true);
        }
    }


    public void Movement()
    {
        float forwardMovement = Input.GetAxis("Vertical");
        float rotationMovement = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0.0f, 0.0f, rotationMovement * speedRotation * Time.deltaTime);
        myRigidbody.AddForce(transform.up * speed * forwardMovement);
        PositionControl();
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
            currentPosition.x = maxX;
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


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isDead = true;
            UiController.Instance.GameOverFeedback();
        }
    }
}
