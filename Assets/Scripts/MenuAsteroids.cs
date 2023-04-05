using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAsteroids : MonoBehaviour
{
    public Asteroid[] asteroids;


    void Start()
    {
        foreach (var asteroid in asteroids)
        {
            asteroid.OnSpawn();
        }
    }

    
}
