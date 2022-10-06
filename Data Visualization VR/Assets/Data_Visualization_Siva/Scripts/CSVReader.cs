using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int tableSize;
    public string[] data;
    public string[] records;
    //public GameObject[] buttonAssert;
    //public GameObject button;


    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ','; // It defines field seperate chracter
    public TextAsset textAssetData;

    [System.Serializable]
    public class Player
    {
        public String name;
        public int health;
        public int damage;
        public int defence;
    }

    [System.Serializable]
    public class PlayerData
    {
    public Player[] player;
    }
    public PlayerData myPlayerList = new PlayerData();
    //public Player nameList = new Player();

    void Start()
    {
        ReadCSV();
    }


    void ReadCSV()
    {
        //string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        //int tableSize = data.Length / 6 - 1;
        //myPlayerList.player = new Player[tableSize];

        //for (int i = 0; i < tableSize; i++)
        //{
        //    myPlayerList.player[i] = new Player();
        //    myPlayerList.player[i].name  = data[4*(i+1)];
        //}


        string[] records = textAssetData.text.Split(lineSeperater);
        string row = records[0];
        string[] noofrows = row.Split(fieldSeperator);
        Debug.Log(noofrows.Length);
        // Debug.Log(records[0]);
        data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        tableSize = data.Length / 4 - 1;

        myPlayerList.player = new Player[tableSize];
        //buttonAssert = new GameObject[noofrows.Length];
        for (int j = 0; j < noofrows.Length; j++)
        {

            Vector3 pos = new Vector3(j * 1, 0, 0);
            //buttonAssert[j] = Instantiate(button, pos, Quaternion.identity);
            //buttonAssert[j].transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = data[j];
        }
        for (int i = 0; i < tableSize; i++)
        {
            Debug.Log(data[i]);

            myPlayerList.player[i] = new Player();
            //myPlayerList.player[i].name = data[4 * (i + 1)];

            //myPlayerList.player[i].health = int.Parse(data[4 * (i + 1) + 1]);
            //myPlayerList.player[i].damage = int.Parse(data[4 * (i + 1) + 2]);
            //myPlayerList.player[i].defence = int.Parse(data[4 * (i + 1) + 3]);
        }
    } 
}
