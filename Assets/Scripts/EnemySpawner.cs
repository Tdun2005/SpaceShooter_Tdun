using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    Camera cam;
    float minX;
    float maxX;
    float spawnY;

    void Start()
    {
        cam = Camera.main;

        // Tính biên camera theo thế giới
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        minX = -camWidth + 0.5f;
        maxX = camWidth - 0.5f;

        // spawn ngay MÉP TRÊN camera
        spawnY = camHeight - 0.5f;

        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        float x = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(x, spawnY, 0);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
