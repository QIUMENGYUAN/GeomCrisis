using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScore : MonoBehaviour
{
    public GameObject gameController;
    public GUISkin skin;

    public static int score = 0;
    public static bool gameOver = false;
    private bool restart;
    private int bestScore;
    public GameObject Dead;
    string ShowInfo = "";
    int flag = 0;


    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        StopAllCoroutines();

        score = PlayerPrefs.GetInt("Score", 0);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        StartCoroutine(AddScore());
    }

    IEnumerator AddScore()
    {
        while (!gameOver)
        {
            ++score;
            yield return new WaitForSeconds(1.0f);
        }
    }
    void OnGUI()
    {
        skin.label.fontSize = Mathf.RoundToInt(80 / ((float)1788 / Screen.width));
        if (!gameOver)
        {
            GUI.Label(new Rect(Screen.width / 18, Screen.height / 20, 400, 400), "Score : " + score, skin.label);
        }
        else
        {
            skin.label.fontSize = Mathf.RoundToInt(100 / ((float)1788 / Screen.width));

            GUI.Label(new Rect(Screen.width / 2 - Screen.width * 2 / 10,
                                Screen.height / 2 - Screen.height * 4 / 12,
                                600,
                                400
                              ),
                              ShowInfo,
                //"   Score : " + score + "\nBest Score : " + bestScore + "\n\n  Tap to restart...",
                       skin.label);
        }
    }

    void Update()
    {

        if (gameOver)
        {
            while (flag < 1)
            {

                Destroy(Instantiate(Dead, PlayerController.playerPosition + new Vector3(0, 0, -1), Quaternion.identity) as GameObject, 5);
                flag++;
                StartCoroutine(showScore(1.5f));
            }


            restart = true;
            GameOver();

            if (Input.GetKey(KeyCode.Escape))
            {

                Application.LoadLevel(0);

            }

        }

        if (!restart)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            StopAllCoroutines();

            gameOver = restart = false;
            //Application.LoadLevelAsync(1);
            Application.LoadLevel(1);
        }
    }
    IEnumerator showScore(float t)
    {
        yield return new WaitForSeconds(t );
        ShowInfo = "   Score : " + score + "\nBest Score : " + bestScore + "\n\n  Tap to restart...";

        yield return new WaitForSeconds(t-0.5f);
        Time.timeScale = 0; //Pause
    }

    void GameOver()
    {
        if (score >= bestScore)
        {
            bestScore = score;
        }
        PlayerPrefs.SetInt("BestScore", bestScore);
        //gameController.SetActive(false);
    }

}
