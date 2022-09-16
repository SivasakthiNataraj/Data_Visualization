using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Space]
    [Header("Environments")]
    [SerializeField]
    private GameObject[] Environment;
    [SerializeField]
    private Material skybox_mat;

    [Space]
    [Header("Level Load")]
    //Level Load
    public Animator GameManageranimator;
    public GameObject Title;

    int fadein,fadeout = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeInCompleted()
    {
        GameManageranimator.SetTrigger("FadeOut");
        fadein++;
        GameFlowControls();
    }

    public void FadeOutCompleted()
    {
        fadeout++;
    }

    public void LoadingCompleted()
    {
        GameFlowControls();
        GameManageranimator.ResetTrigger("FadeOut");
    }

    public void EnableTitle()
    {
        StartCoroutine(TitleDelay());
    }

    IEnumerator TitleDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Title.SetActive(true);
        GameManageranimator.Play("Title");
    }

    public void GameFlowControls()
    {
        if (fadein == 1 && fadeout == 0)
        {
            EnableTitle();
        }
        else if (fadein == 1 && fadeout == 1)
        {
            EnableEnvironment();
        }
    }


    public void EnableEnvironment()
    {
        Destroy(Title);
        RenderSettings.skybox = skybox_mat;
        Environment[0].SetActive(true);
        Environment[1].SetActive(true);
    }
}
