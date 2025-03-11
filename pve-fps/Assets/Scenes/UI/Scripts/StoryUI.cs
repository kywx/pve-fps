using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryUI : MonoBehaviour
{
    public Button skip;
    public Button next;
    public Button prev;
    public GameObject pagesObject;
    private GameObject[] pageList;
    private int page;
    private int firstIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        page = firstIndex; // start on the first page
        // subscribe buttons
        skip.onClick.AddListener(() => SkipStory());
        prev.onClick.AddListener(() => ShiftLeft());
        next.onClick.AddListener(() => ShiftRight());
        Image[] stuff = pagesObject.GetComponentsInChildren<Image>(true);
        pageList = new GameObject[stuff.Length];
        int i = 0;
        foreach (Image thing in stuff)
        {
            //pageList.Append(thing.gameObject);
            pageList[i] = thing.gameObject;
            i++;
        }

    }


    private void SkipStory()
    {
        SceneManager.LoadScene("MainLevel");
        //this.gameObject.SetActive(false);
        //ChangePage(page, firstIndex);
        //page = firstIndex;
    }

    private void ShiftLeft()
    {
        if (page > firstIndex)
        {
            ChangePage(page, page - 1);
            page -= 1;
        }
    }

    private void ShiftRight()
    {
        if (page == pageList.Length - 1)
        {
            SceneManager.LoadScene("MainLevel");
        }
        if (page < pageList.Length - 1)
        {
            ChangePage(page, page + 1);
            page += 1;
        }
    }

    private void ChangePage(int old_index, int new_index)
    {
        // change page based on index
        pageList[old_index].SetActive(false);
        pageList[new_index].SetActive(true);
        // set buttons (if page = 0, set left to inactive, if page = pageList.Length-1, set right to inactive)

    }
}
