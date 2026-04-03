using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static readonly GameManager instance = new GameManager();
    public static GameManager Instance => instance;

    private int life;
    private int score;
    public int CurrentLife => life;
    public int CurrentScore => score;

    private GameManager() { }

    public void AddLife()
    {
        life++;
    }

    public void LoseLife()
    {
        life--;
    }

    public void ResetLife()
    {
        life = 3;
    }

    public void AddScore()
    {
        score++;
    }

    public void LoseScore()
    {
        score = score - 10;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void Reset()
    {
        life = 3;
        score = 0;
    }
}
