using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 480.0f;

    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    public Sprite[] walkSprites;
    public Sprite[] jumpSprites;
    public Image[] life;
    public TextMeshProUGUI score;

    float time = 0;
    int idx = 0;
    SpriteRenderer spriteRenderer;

    public GameObject goalObject;

    // 시작 위치 저장
    Vector3 startPosition;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        startPosition = transform.position;
        GameManager.Instance.Reset();
    }

    void Update()
    {
        if(GameManager.Instance.CurrentLife > 0)
        {
            // 떨어졌을 때
            if (transform.position.y < -10)
            {
                GameManager.Instance.LoseLife();
                switch (GameManager.Instance.CurrentLife)
                {
                    case 0:
                        life[0].gameObject.SetActive(false);
                        life[1].gameObject.SetActive(false);
                        life[2].gameObject.SetActive(false);
                        break;
                    case 1:
                        life[0].gameObject.SetActive(true);
                        life[1].gameObject.SetActive(false);
                        life[2].gameObject.SetActive(false);
                        break;
                    case 2:
                        life[0].gameObject.SetActive(true);
                        life[1].gameObject.SetActive(true);
                        life[2].gameObject.SetActive(false);
                        break;
                    case 3:
                        life[0].gameObject.SetActive(true);
                        life[1].gameObject.SetActive(true);
                        life[2].gameObject.SetActive(true);
                        break;
                }

                    if (GameManager.Instance.CurrentLife > 0)
                {
                    Respawn();
                }
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(this.rigid2D.linearVelocity.y) < 0.01f)
                {
                    this.rigid2D.AddForce(transform.up * this.jumpForce);
                }

                if (this.rigid2D.linearVelocity.x < this.maxWalkSpeed)
                {
                    this.rigid2D.AddForce(transform.right * this.walkForce);
                }

                if (Mathf.Abs(this.rigid2D.linearVelocity.y) > 0.01f)
                {
                    this.spriteRenderer.sprite = this.jumpSprites[0];
                }
                else
                {
                    this.time += Time.deltaTime;
                    if (this.time >= 0.1f)
                    {
                        this.time = 0;
                        this.spriteRenderer.sprite = this.walkSprites[this.idx];
                        this.idx = 1 - this.idx;
                    }
                }
            }
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        rigid2D.linearVelocity = Vector2.zero;
        rigid2D.angularVelocity = 0f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == goalObject)
        {
            SceneManager.LoadScene("ClearGameScene");
        }

        if (collision.CompareTag("star"))
        {
            StarItem starItem = collision.GetComponent<StarItem>();

            if (starItem != null)
            {
                GameManager.Instance.AddScore(starItem.scoreValue);
            }
            else
            {
                GameManager.Instance.AddScore(1);
            }

            collision.gameObject.SetActive(false);
            score.text = "Score: " + GameManager.Instance.CurrentScore;
        }
    }
}