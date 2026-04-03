using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public ItemDropSpawner spawner;
    public float destroyY = -7f;

    void Update()
    {
        if (transform.position.y < destroyY)
        {
            NotifyAndDestroy();
        }
    }

    void OnDisable()
    {
        // 플레이어가 먹어서 SetActive(false) 되었을 때도 생성 개수 복구
        if (gameObject.scene.isLoaded && spawner != null)
        {
            spawner.OnItemDestroyed();
        }
    }

    void NotifyAndDestroy()
    {
        if (spawner != null)
        {
            spawner.OnItemDestroyed();
        }

        Destroy(gameObject);
    }
}