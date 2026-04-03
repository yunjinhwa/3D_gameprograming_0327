using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.ResetLife();
        SceneManager.LoadScene("GameScene");
    }
}
