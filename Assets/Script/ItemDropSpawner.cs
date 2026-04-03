using UnityEngine;

public class ItemDropSpawner : MonoBehaviour
{
    [Header("별 프리팹")]
    public GameObject normalStarPrefab;
    public GameObject rareStarPrefab;

    [Header("희귀 별 등장 확률(0~1)")]
    [Range(0f, 1f)]
    public float rareSpawnChance = 0.2f;

    [Header("생성 범위")]
    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 6f;

    [Header("생성 주기")]
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.5f;

    [Header("동시 최대 생성 개수")]
    public int maxItemCount = 10;

    private int currentItemCount = 0;

    void Start()
    {
        SpawnLoop();
    }

    void SpawnLoop()
    {
        if (currentItemCount < maxItemCount)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);

            GameObject selectedPrefab = Random.value < rareSpawnChance
                ? rareStarPrefab
                : normalStarPrefab;

            if (selectedPrefab != null)
            {
                GameObject item = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
                currentItemCount++;

                FallingItem fallingItem = item.GetComponent<FallingItem>();
                if (fallingItem == null)
                {
                    fallingItem = item.AddComponent<FallingItem>();
                }

                fallingItem.spawner = this;
            }
        }

        float nextTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke(nameof(SpawnLoop), nextTime);
    }

    public void OnItemDestroyed()
    {
        currentItemCount--;

        if (currentItemCount < 0)
            currentItemCount = 0;
    }
}