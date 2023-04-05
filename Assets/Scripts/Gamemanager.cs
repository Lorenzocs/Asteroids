using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private int points;
    public ObjectPool bigAsteroidPool, smallAsteroidPool;
    public int amountOfBigAsteroids;
    public float spawnOffset = 1f;
    private Camera mainCamera;
    [SerializeField] private Player player;
    [SerializeField] private int safeRange;
    public static Gamemanager Instance;
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        mainCamera = Camera.main;
        SpawnObject();
    }


    public void Update()
    {
        if (amountOfBigAsteroids < 5)
        {
            SpawnObject();
        }
    }


    private void SpawnObject()
    {
        amountOfBigAsteroids++;
        Vector3 spawnPosition = GetRandomSpawnPosition(player.transform.position, safeRange);
        GameObject bigAsteroid = bigAsteroidPool.GetObject();
        bigAsteroid.GetComponent<BigAsteroid>().OnSpawn();
        bigAsteroid.transform.position = spawnPosition;
        bigAsteroid.SetActive(true);
    }


    private Vector3 GetRandomSpawnPosition(Vector3 playerPos, float minSpawnDistance)
    {
        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        Vector3 spawnPos;
        do
        {
            float spawnX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
            float spawnY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);
            spawnPos = new Vector3(spawnX, spawnY, 0f);
        } while (Vector3.Distance(spawnPos, playerPos) < minSpawnDistance);
        return spawnPos;
    }


    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        UiController.Instance.UpdatePoints(points);
    }


    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.transform.position, safeRange);
    }
}
