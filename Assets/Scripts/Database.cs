using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    public Canvas monitorScreen;
    public List<Paper> allPaper;
    public GameObject indexPage;
    public GameObject resultPage;
    public GameObject resultItem;
    public GameObject paperPage;
    public GameObject figureItem;
    private string keywords = "";
    private List<Paper> lastSearch;

    private void ShowIndex() {
        ClearPage();
        GameObject ip = Instantiate(indexPage, monitorScreen.transform);
        ip.GetComponentInChildren<InputField>().onEndEdit.AddListener(endEdit);
        ip.GetComponentInChildren<Button>().onClick.AddListener(ClickSearchButton);
    }
    private void ShowSearchResult(List<Paper> papers) {
        lastSearch = papers;
        ClearPage();
        GameObject rp = Instantiate(resultPage, monitorScreen.transform);
        rp.GetComponentInChildren<InputField>().onEndEdit.AddListener(endEdit);
        Button[] bs = rp.GetComponentsInChildren<Button>();
        bs[0].onClick.AddListener(ShowIndex);
        bs[1].onClick.AddListener(ClickSearchButton);
        GameObject content = rp.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject;
        foreach(Paper p in papers) {
            GameObject tmp = Instantiate(resultItem, content.transform);
            tmp.GetComponent<ResultItem>().p = p;
            tmp.GetComponent<Text>().text = p.title;
            tmp.GetComponent<Button>().onClick.AddListener(() => { ShowPaper(p); });
        }
    }
    private void ShowPaper(Paper p) {
        ClearPage();
        GameObject pp = Instantiate(paperPage, monitorScreen.transform);
        Button[] bs = pp.GetComponentsInChildren<Button>();
        bs[0].onClick.AddListener(()=> { ShowSearchResult(lastSearch); });
        bs[1].onClick.AddListener(ShowIndex);
        GameObject content = pp.transform.GetChild(0).GetChild(1).gameObject;
        content.transform.GetChild(0).GetComponent<Text>().text = p.title;
        content.transform.GetChild(1).GetComponent<Text>().text = p.ab;
        GameObject figures = content.transform.GetChild(2).gameObject;
        foreach (Figure f in p.figures)
        {
            GameObject tmp = Instantiate(figureItem, figures.transform);
            tmp.GetComponent<Image>().sprite = f.img;
            tmp.GetComponent<FigureItem>().f = f;
        }
    }
    private void ClearPage() {
        keywords = "";
        int childCount = monitorScreen.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--) {
            Destroy(monitorScreen.transform.GetChild(i).gameObject);
        }
    }
    private void endEdit(string s) {
        print(s);
        keywords = s;
    }

    public void ClickIndexButton() { }
    public void ClickSearchButton() {
        if (keywords == "") {
            return;
        }
        List<Paper> result = new List<Paper>();

        foreach (Paper p in allPaper) {
            if (p.title.Contains(keywords) || p.ab.Contains(keywords)) {
                result.Add(p);
            }
        }

        ShowSearchResult(result);
    }
    public void ClickPaper() { }
    public void ClickFigure() { }

    private void Start()
    {
        ShowIndex();
        lastSearch = new List<Paper>();
    }
}
