using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public Button mainMenu;
    public Button leftButton;
    public Button rightButton;
    public GameObject pagesObject;
    private GameObject[] pageList;
    private int page;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        page = 1; // start on the first page
        // subscribe buttons
        mainMenu.onClick.AddListener(() => EndTutorial());
        leftButton.onClick.AddListener(() => ShiftLeft());
        rightButton.onClick.AddListener(() => ShiftRight());
        RectTransform[] stuff = pagesObject.GetComponentsInChildren<RectTransform>(true);
        pageList = new GameObject[stuff.Length];
        int i = 0;
        foreach (RectTransform thing in stuff)
        {
            //pageList.Append(thing.gameObject);
            pageList[i] = thing.gameObject;
            i++;
        }
        
    }


    private void EndTutorial()
    {
        this.gameObject.SetActive(false);
        ChangePage(page, 1);
        page = 1;
    }

    private void ShiftLeft()
    {
        if (page > 1)
        {
            ChangePage(page, page-1);
            page -= 1;
        }
    }

    private void ShiftRight()
    {
        if (page < pageList.Length-1)
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
