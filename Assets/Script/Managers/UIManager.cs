using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text livesText;
    public PlayerControl player;
    public GameObject gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = $"Lifes: {player.GetLifes()}";
        IsGameOver();
    }

    private void IsGameOver()
    {
        if (!player.IsAlive())
        {
            gameOverScreen.SetActive(true);
        }
    }
}