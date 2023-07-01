using DG.Tweening;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject panel,rules,playb,rulesb,quitb,menub;
    void Start()
    {
        playb.transform.DOScale(new Vector3(1, 1.5f, 1.5f), 1).SetLoops(-1,LoopType.Yoyo);
        rulesb.transform.DOScale(new Vector3(1, 1.5f, 1.5f), 1).SetLoops(-1, LoopType.Yoyo);
        quitb.transform.DOScale(new Vector3(1, 1.5f, 1.5f), 1).SetLoops(-1, LoopType.Yoyo);
       
    }

  
    public void Play()
    {
        panel.SetActive(false);
        menub.SetActive(true);
        rules.SetActive(false);
    }
    public void Rules()
    {
        rules.SetActive(true);
        panel.SetActive(false);
        menub.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        if(!panel.activeInHierarchy)
        panel.SetActive(true); 
        rules.SetActive(false);
    }
}
