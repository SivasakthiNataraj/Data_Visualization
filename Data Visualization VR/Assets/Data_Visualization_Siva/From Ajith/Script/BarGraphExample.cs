using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq.Expressions;
using BarGraph.VittorCloud;

public class BarGraphExample : MonoBehaviour
{
    public int abc;
    public TextAsset csvfile;
    public List<BarGraphDataSet> exampleDataSet; // public data set for inserting data into the bar graph
    BarGraphGenerator barGraphGenerator;
    [System.Serializable]
    public class player
    {
        public string name;
        public int salary, year, leavebal, totalleave, monthlysal;
    }
    [System.Serializable]
    public class playerlist
    {
        public player[] player;

    }
    playerlist pl = new playerlist();
    void Start()
    {
       
        string[] data = csvfile.text.Split(new string[] { "\n", "," }, StringSplitOptions.None);
        Debug.Log(data.Length);
        int tablesize = (data.Length - 1) / 6 - 1;
        pl.player = new player[tablesize];
        for (int i = 0; i < tablesize; i++)
        {
            pl.player[i] = new player();
            pl.player[i].name = data[6 * (i + 1)];
            //BarGraphDataSet.ListOfBars[i].XValue =
            //BarGraphDataSet.ListOfBars[i].YValue = float.Parse( data[6 * (i + 1)+1]);
            Debug.Log("ok");
            pl.player[i].year = int.Parse(data[6 * (i + 1) + 1]);
            pl.player[i].salary = int.Parse(data[6 * (i + 1) + 2]);
            pl.player[i].monthlysal = int.Parse(data[6 * (i + 1) + 3]);
            pl.player[i].leavebal = int.Parse(data[6 * (i + 1) + 4]);
            pl.player[i].totalleave = int.Parse(data[6 * (i + 1) + 5]);

        }
        barGraphGenerator = GetComponent<BarGraphGenerator>();
       // exampleDataSet[0].ListOfBars[0].XValue = "ram";
        //Debug.Log(exampleDataSet[0].ListOfBars[0].XValue);
        for (int j = 0; j <19; j++)
        {
            exampleDataSet[j].GroupName = pl.player[j].name;
            for (int k = 0; k < 5; k++)
            {
              
                 if (k == 0)
                {
                    exampleDataSet[j].ListOfBars[k].XValue = "year";
                    exampleDataSet[j].ListOfBars[k].YValue = pl.player[j].year;
                }
                else if (k == 1)
                {
                    exampleDataSet[j].ListOfBars[k].XValue = "salary";
                    exampleDataSet[j].ListOfBars[k].YValue = pl.player[j].salary;
                }
                else if (k == 2)
                {
                    exampleDataSet[j].ListOfBars[k].XValue = "monthlysal";
                    exampleDataSet[j].ListOfBars[k].YValue = pl.player[j].monthlysal;
                }
                else if (k == 3)
                {
                    exampleDataSet[j].ListOfBars[k].XValue = "leavebal";
                    exampleDataSet[j].ListOfBars[k].YValue = pl.player[j].leavebal;
                }
                else if (k == 4)
                {
                    exampleDataSet[j].ListOfBars[k].XValue = "totalleave";
                    exampleDataSet[j].ListOfBars[k].YValue = pl.player[j].totalleave;
                }
               
            }


        }
       
        //if the exampleDataSet list is empty then return.
        if (exampleDataSet.Count == 0)
        {

            Debug.LogError("ExampleDataSet is Empty!");
            return;
        }
        else
        {
            
            barGraphGenerator.GeneratBarGraph(exampleDataSet);
        }
    }
    


    //call when the graph starting animation completed,  for updating the data on run time
    public void StartUpdatingGraph()
    {

       
        StartCoroutine(CreateDataSet());
    }



    IEnumerator CreateDataSet()
    {
        //  yield return new WaitForSeconds(3.0f);
        while (true)
        {

            GenerateRandomData();

            yield return new WaitForSeconds(2.0f);

        }

    }



    //Generates the random data for the created bars
    void GenerateRandomData()
    {
        
        int dataSetIndex = UnityEngine.Random.Range(0, exampleDataSet.Count);
        int xyValueIndex = UnityEngine.Random.Range(0, exampleDataSet[dataSetIndex].ListOfBars.Count);
        exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue = UnityEngine.Random.Range(barGraphGenerator.yMinValue, barGraphGenerator.yMaxValue);
        barGraphGenerator.AddNewDataSet(dataSetIndex, xyValueIndex, exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue);
    }
}



