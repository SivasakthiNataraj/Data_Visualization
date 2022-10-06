using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShow : MonoBehaviour
{
    public static string[] getName;
    public GameObject[] buttonobj;
    public GameObject[] buttonshow;

    public string[] gameObjectName;
    // Start is called before the first frame update
    void Start()
    {
        getName = new string[19];
        getname();
    }
    public void getname()
    {
        for (int i = 0; i <buttonobj.Length; i++)
        {
            getName[i] = buttonobj[i].name;

        }
    }
    public void Update()
    {
        buttons();
    }

    public  void buttons()
    {
        for(int i=0;i<19;i++)
        {
            if (buttonshow[i].name== BallPrefab.selectedobj)
            {
               buttonshow[i].SetActive(true);
                Debug.Log("button" + buttonshow[i]);
            }
        }
    }

}
