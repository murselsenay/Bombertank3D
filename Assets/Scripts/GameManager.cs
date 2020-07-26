using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public GameObject popMessagePrefab;
    public GameObject pausePanelPrefab;
    public GameObject nextLevelPanelPrefab;
    public GameObject gameOverPanelPrefab;
    public GameObject infoPanelPrefab;
    public Text bombCountUIText;
    public static GameManager instance;
    bool canCheckLevelIsSuccessed = true;
    [Header("Achievements Count")]
    GameObject[] achText;
    public int[] achs;

    void Start()
    {
        if (achText == null)
            achText = GameObject.FindGameObjectsWithTag("AchText");
        instance = this;
        Time.timeScale = 1;
        UpdateAchTexts();
        UpdateBombCountUIText(Tank.droppableBombCount.ToString());
    }

    void Update()
    {
        if (CheckLevelIsSuccessed())
        {
            canCheckLevelIsSuccessed = false;
            NextLevelScreen();
            //Game Over
        }
    }
    public void UpdateAchTexts()
    {
        for (int i = 0; i < achText.Length; i++)
        {
            achText[i].GetComponent<Text>().text = achs[i].ToString();
            if (achs[i] <= 0)
            {
                achText[i].GetComponent<Text>().text = "OK";
            }
        }

    }
    public bool CheckLevelIsSuccessed()
    {

        if (canCheckLevelIsSuccessed)
        {
            if (achs[0] <= 0 && achs[1] <= 0)
            {
                return true;
            }
        }
        return false;

    }
    public void PauseMenu()
    {
        ShowPanel(pausePanelPrefab, true, "Paused");

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {

        Time.timeScale = 1;
        GameObject.Find("PauseBtn").GetComponent<Button>().interactable = true;
        Destroy(GameObject.Find("PauseGamePanel(Clone)"));
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void NextLevelScreen()
    {
        ShowPanel(nextLevelPanelPrefab, true, "Congratulations ! \nGo Next Level!");
    }

    public void GameOverScreen()
    {
        ShowPanel(gameOverPanelPrefab, true, "Game Over \nTry Again !");
    }
    public void ExitBtn()
    {
        Time.timeScale = 1;
        Destroy(GameObject.FindGameObjectWithTag("InfoPanel"));
    }
    public void ShowPanel(GameObject prefab, bool textUpdate, string _text = "-")
    {
        GameObject.Find("PauseBtn").GetComponent<Button>().interactable = false;
        GameObject insPrefab = Instantiate(prefab, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        insPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("CameraCanvas").transform);
        if (textUpdate)
            insPrefab.transform.GetChild(0).GetComponent<Text>().text = _text;
        Invoke("PauseGame", 0.5f);
    }
    public void ShowPopMessage(string text)
    {
        GameObject insPopMessage = Instantiate(popMessagePrefab);
        insPopMessage.GetComponent<PopMessage>().UpdateText(text);
    }
    public void UpdateBombCountUIText(string text)
    {
        bombCountUIText.text = text;
    }
}
