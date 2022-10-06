using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class namescr : MonoBehaviour
{
    public static string[] getName;
    public GameObject[] buttonobj;
    public GameObject[] buttonshow;

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
        Debug.Log("buttons");
        for(int i=0;i<19;i++)
        {
            if(buttonshow[i].name==ontriger.selectedobj)
            {
                buttonshow[i].SetActive(true);
                buttonshow[i].transform.position = new Vector3(0f, 2f, 0f);

            }
            
        }
    }

}
