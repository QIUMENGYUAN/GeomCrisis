using UnityEngine;
using System.Collections;

public class PlayOnClick : MonoBehaviour
{

    public GUISkin Skin;
    public Texture2D Play;
    public Texture2D Clear;
    public GameObject HasBeen;
    void Awake()
    {
        Time.timeScale = 1;
    }
    void OnGUI()
    {
        Skin.button.normal.background = Play;
        if (GUI.Button(new Rect(
            Screen.width / 2 ,
            Screen.height * 10 / 13,
            Play.width / ((float)1788 / Screen.width) * 0.9f,
            Play.height / ((float)1000 / Screen.height) * 0.9f), "", Skin.button))
        {

            Application.LoadLevelAsync(1);

        }
        Skin.button.normal.background = Clear;
        if (GUI.Button(new Rect(
            Screen.width * 3 / 22,
            Screen.height * 29 / 40,
            Clear.width / ((float)1788 / Screen.width) * 0.4f,
            Clear.height / ((float)1000 / Screen.height) * 0.4f), "", Skin.button))
        {
            PlayerPrefs.SetInt("CheckPoint", 0);
            Destroy(Instantiate(HasBeen, new Vector3(0, 0, -3), Quaternion.identity) as GameObject, 2);
        }

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
