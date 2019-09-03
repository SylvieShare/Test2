using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHP;
    public TextMeshProUGUI textGameOver;
    public GameObject Player;
    public Canvas CanvasGame;
    public Canvas CanvasMenu;
    public static int Score;
    public static float HPPlayer;
    public static float HPPlayerMax;
    public static GameController gameController;
    public float scaletime;

    // Start is called before the first frame update
    void Start()
    {
        gameController = this;
        Score = 0;
        Time.timeScale = 0;
        CanvasGame.enabled = false;
        textGameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "SCORE: " + Score;

        textHP.text = "HP: " + HPPlayer;
        textHP.color = new Color(1 - HPPlayer / HPPlayerMax, 1 * HPPlayer / HPPlayerMax, 0, 1);

        if (HPPlayer <= 0 && !CanvasMenu.enabled)
        {
            textGameOver.enabled = true;
            StartCoroutine(StopGameSlow());
        }
    }

    IEnumerator StopGameSlow()
    {
        yield return new WaitForSeconds(0);
        while (Time.timeScale > 0)
        {
            Time.timeScale -= 0.001f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void StartGame()
    {
        CanvasMenu.enabled = false;
        CanvasGame.enabled = true;
        Time.timeScale = scaletime;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
