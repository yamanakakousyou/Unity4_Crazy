using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [Header("出現させる車のPrefab")]
    [SerializeField] private GameObject[] carPrefabs;

    [Header("複数の出現位置")]
    [SerializeField] private Transform[] spawnPoints;

    [Header("道路の右端")]
    [SerializeField] private Transform roadEdge;

    [Header("出現間隔")]
    [SerializeField] private float spawnInterval = 3f;

    private float timer;

    private void Update()
    {
        if (carPrefabs == null || carPrefabs.Length == 0 ||
            spawnPoints == null || spawnPoints.Length == 0)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer -= spawnInterval;
            SpawnCar();
        }
    }

    private void SpawnCar()
    {
        GameObject prefab =
            carPrefabs[Random.Range(0, carPrefabs.Length)];

        Transform point =
            spawnPoints[Random.Range(0, spawnPoints.Length)];

        if (prefab == null || point == null)
            return;

        GameObject car = Instantiate(
            prefab,
            point.position,
            point.rotation
        );

        CarMover mover = car.GetComponent<CarMover>();

        if (mover == null)
            mover = car.AddComponent<CarMover>();

        mover.SetRoadEdge(roadEdge);
    }
}