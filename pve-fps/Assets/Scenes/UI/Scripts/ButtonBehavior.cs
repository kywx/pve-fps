using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    //public Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //button = GetComponent<Button>();
        //button.onClick.AddListener(StartButton);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
