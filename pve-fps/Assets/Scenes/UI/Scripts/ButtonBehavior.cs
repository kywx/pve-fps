using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject tutorial;
    void Start()
    {

    }

    public void StartButton()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void StartTutorial()
    {
        tutorial.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
