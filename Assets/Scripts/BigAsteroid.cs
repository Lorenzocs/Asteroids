using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : Asteroid
{

    protected override void Update()
    {
        base.Update();
    }


    protected override void DestroyAsteroid()
    {
        int asteroidToSpawn = Random.Range(2, 5);
        List<Vector3> directions = new List<Vector3>();
        for (int i = 0; i < asteroidToSpawn; i++)
        {
            GameObject asteroid = Gamemanager.Instance.smallAsteroidPool.GetObject();
            asteroid.transform.position = transform.position;
            asteroid.transform.rotation = transform.rotation;
            SmallAsteroid myAsteroid = asteroid.GetComponent<SmallAsteroid>();
            var direction = Random.onUnitSphere;
            myAsteroid.rb.AddForce(direction, ForceMode2D.Impulse);
            asteroid.SetActive(true);
        }
        Gamemanager.Instance.amountOfBigAsteroids--;
        base.DestroyAsteroid();
    }

}
