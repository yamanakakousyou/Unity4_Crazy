
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [Header("出現させる車のPrefab")]
    [SerializeField] private GameObject[] carPrefabs;

    [Header("複数の出現位置")]
    [SerializeField] private Transform[] spawnPoints;

    [Header("出現間隔")]
    [SerializeField] private float spawnInterval = 3f;

    private float timer;

    private void Update()
    {
        if (carPrefabs == null || carPrefabs.Length == 0 ||
            spawnPoints == null || spawnPoints.Length == 0)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer -= spawnInterval;

            // 車をランダムに選ぶ
            int carIndex = Random.Range(0, carPrefabs.Length);

            // スポーンポイントをランダムに選ぶ
            int spawnIndex = Random.Range(0, spawnPoints.Length);

            GameObject selectedCar = carPrefabs[carIndex];
            Transform selectedPoint = spawnPoints[spawnIndex];

            if (selectedCar != null && selectedPoint != null)
            {
                Instantiate(
                    selectedCar,
                    selectedPoint.position,
                    selectedPoint.rotation
                );
            }
        }
    }
}
