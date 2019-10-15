using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float scrollSpeed { get; set; } = 0.5f;
    public int score { get; set; } = 0;
    public int life { get; set; } = 4;
    void Awake() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
    public void AddScore(int score) {
        this.score += score;
    }
}
