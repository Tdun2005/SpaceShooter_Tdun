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

        // tính kích thước camera
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        // biên trái phải (chừa lề cho enemy)
        minX = -camWidth + 0.5f;
        maxX = camWidth - 0.5f;

        // spawn NGOÀI MÀN HÌNH (phía trên)
        spawnY = camHeight + 1.5f;

        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        float x = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(x, spawnY, 0f);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
