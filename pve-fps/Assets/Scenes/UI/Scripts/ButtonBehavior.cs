using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject story;
    void Start()
    {

    }

    public void StartButton()
    {
        story.SetActive(true);
        //SceneManager.LoadScene("MainLevel");
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
