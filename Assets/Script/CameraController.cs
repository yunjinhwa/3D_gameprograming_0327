using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    public float minX = -20f; // 카메라의 최소 x 위치
    public float maxX = 150f; // 카메라의 최대 x 위치
    void Start()
    {
        this.player = GameObject.Find("catWalkA_0"); // "player"라는 이름의 게임 오브젝트를 찾아서 player 변수에 할당
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position; // player의 현재 위치를 가져옴
        float clampedX = Mathf.Clamp(playerPos.x, this.minX, this.maxX); // player의 x 위치를 카메라의 최소와 최대 x 위치 사이로 제한
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z); 
        // 카메라의 x 위치를 제한된 player의 x 위치로 설정, y와 z는 그대로 유지
    }
}
