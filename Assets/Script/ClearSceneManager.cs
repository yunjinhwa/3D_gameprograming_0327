using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClearSceneManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    void Start()
    {
        score.text = "Score: " + GameManager.Instance.CurrentScore;
        Invoke("LoadNextScene", 3f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}