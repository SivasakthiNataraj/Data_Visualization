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

    int fadein, fadeout = 0;

    public ReadCSV readcsvManager;
    //public string EmpName;



    [Space]
    [Space]
    [Header("Sound EFX")]
    public AudioSource[] SoundEFX;

    public GameObject _AppQuit;
    public GameObject Bubble_Interaction;

    // Start is called before the first frame update
    void Start()
    {
        GameManageranimator.Play("Fade_In");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIN()
    { 
        GameManageranimator.Play("Fade_In");
    }
    public void FadeOUT()
    {
        GameManageranimator.Play("Fade_Out");
    }

    public void LoadinAnim()
    { 
        GameManageranimator.Play("Loading");
    }
    public void FadeInCompleted()
    {
        //GameManageranimator.SetTrigger("FadeOut");
        fadein++;
        GameFlowControls();
    }

    public void FadeOutCompleted()
    {
        LoadinAnim();
        fadeout++;
    }

    public void LoadingCompleted()
    {
        GameFlowControls();
        FadeIN();

        //GameManageranimator.ResetTrigger("FadeOut");
    }

    public void EnableTitle()
    {
        StartCoroutine(TitleDelay());
    }

    IEnumerator TitleDelay()
    {
        Title.SetActive(true);
        GameManageranimator.Play("Title");
        yield return new WaitForSeconds(6f);
        FadeOUT();
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
        FadeIN();
        Environment[0].SetActive(true);
        Environment[1].SetActive(false);
    }



    public void CreateGraphBar(int ID, Color _color,string EmpName)
    {
        //readcsvManager.bubbleName = EmpName;
        //Debug.Log("Create bar with : " + EmpName);

        readcsvManager.GraphGenerate(ID, _color, EmpName);
        Graph_Bar_BuildSoundEFX();
    }


    public void RemoveGraph(int ID,string EmpName)
    {
        readcsvManager.RemoveFromGraph(ID, EmpName);
        Graph_Bar_BuildSoundEFX();
    }


    public void EnableBubble()
    {
        Debug.Log("EnableBubble");
        StartCoroutine(BubbleEnableDelay());
    }

    IEnumerator BubbleEnableDelay()
    {
        yield return new WaitForSeconds(3.0f);
        readcsvManager.ReadCSVFile();
        Enable_BubbleSoundEFX();
    }


    public void PickupSoundEFX()
    {
        SoundEFX[0].Play();
    }

    public void Ball_PickSoundEFX()
    {
        SoundEFX[4].Play();
    }

    public void Enable_BubbleSoundEFX()
    {
        SoundEFX[3].Play();
    }

    public void IpadONSoundEFX()
    {
        SoundEFX[1].Play();
    }

    public void Graph_BottomSoundEFX()
    {
        SoundEFX[2].Play();
    }

    public void Ball_Graph_interactionSoundEFX()
    {
        SoundEFX[5].Play();
        Bubble_Interaction.SetActive(true);
        StartCoroutine(EnableCollidable());
    }

    public void Graph_Bar_BuildSoundEFX()
    {
        SoundEFX[6].Play();
    }

    public void Game_OFFSoundEFX()
    {
        SoundEFX[7].Play();
    }

    public void WooshSoundEFX()
    {
        SoundEFX[8].Play();
    }

    public void ApplicationQuit()
    {
        _AppQuit.SetActive(true);
        Game_OFFSoundEFX();
        StartCoroutine(AppQuit());
    }
    IEnumerator AppQuit()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Exit App");
        Application.Quit();
    }

    IEnumerator EnableCollidable()
    {
        yield return new WaitForSeconds(0.5f);
        Bubble_Interaction.SetActive(false);
    }

}
