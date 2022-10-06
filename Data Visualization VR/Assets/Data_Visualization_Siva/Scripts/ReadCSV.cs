using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Random = UnityEngine.Random;

public class ReadCSV : MonoBehaviour
{

    public GameManager _gameManager;

    public TextAsset textAssetData;

    public string EmpName;

    [Space]
    [Header("Graph")]
    public GameObject removingbar;
    [Space]
    [Space]
    [Space]
    public GameObject graph_Bar;
    public GameObject Emp_Name;
    public Transform Graph_Parent;
    public GameObject Year_Parent;
    public float x, z, scalingSpeed;
    public float scalingDuration;
    public Vector3 minScale;
    public Vector3 maxScale;


    public List<float> Zpos;





    public int tableSize;




    [Space]
    [Header("Bubble")]
    public GameObject[] BubbleContainer;
    public GameObject BubblePrefeb;
    public string bubbleName;
    public Material newMat;
    public BubbleScript bubbleScript;

    [System.Serializable]
    public class Player
    {
        public string name;
        public int Year;
        public float YearScale;
        public int YearSalary;
        public float YearSalaryScale;
        public int MonthlySalary;
        public float MonthlySalaryScale;
        public int LeaveBalance;
        public float LeaveBalanceScale;
        public int TotalLeave;
        public float TotalLeaveScale;
    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }
    public PlayerList myplayerList = new PlayerList();

    private void Start()
    {

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _gameManager.readcsvManager = this.gameObject.GetComponent<ReadCSV>();
        //Invoke("ReadCSVFile", 3.0f);
        //bubbleName = BubblePrefeb.transform.GetChild(0).transform.GetChild(0).name;
        //Debug.Log(bubbleName);
    }
    private void Update()
    {

    }



    public void ReadCSVFile()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        tableSize = data.Length / 6 - 1;
        myplayerList.player = new Player[tableSize];
        //int j = 0;
        for (int i = 0; i < tableSize; i++)
        {
            myplayerList.player[i] = new Player();
            myplayerList.player[i].name = data[6 * (i + 1)];
            var colorpalatte = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            BubbleCreate(colorpalatte, i);
            myplayerList.player[i].Year = int.Parse(data[6 * (i + 1) + 1]);
            myplayerList.player[i].YearSalary = int.Parse(data[6 * (i + 1) + 2]);
            myplayerList.player[i].MonthlySalary = int.Parse(data[6 * (i + 1) + 3]);
            myplayerList.player[i].LeaveBalance = int.Parse(data[6 * (i + 1) + 4]);
            myplayerList.player[i].TotalLeave = int.Parse(data[6 * (i + 1) + 5]);
            //if (j < 10)
            //{
            //    myplayerList.player[i].Year = int.Parse(data[6 * (i + 1) + 1]);
            //    if (myplayerList.player[i].Year != 0)
            //    {
            //        myplayerList.player[i].YearScale = 0.75f;
            //        Debug.Log(myplayerList.player[i].YearScale);
            //        var year = Instantiate(graph_Bar);
            //        year.transform.SetParent(Graph_Parent.transform);
            //        year.transform.localScale = new Vector3(0.4f,0.035f, 0.4f);
            //        maxScale = new Vector3(0.01f, myplayerList.player[i].YearScale, 0.01f);
            //        StartCoroutine(RepeatLerping(year, minScale, maxScale, scalingDuration));
            //        //year.transform.GetChild(0).transform.localScale = new Vector3(0.01f, myplayerList.player[i].YearScale, 0.01f);
            //        year.transform.localPosition = new Vector3(x, 0, z);
            //        year.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = colorpalatte;
            //        x += 2f;
            //    }
            //    myplayerList.player[i].YearSalary = int.Parse(data[6 * (i + 1) + 2]);
            //    if (myplayerList.player[i].YearSalary != 0)
            //    {
            //        var yearSalary = Instantiate(graph_Bar);
            //        yearSalary.transform.SetParent(Graph_Parent.transform);
            //        myplayerList.player[i].YearSalaryScale = (myplayerList.player[i].YearSalary / 12) / 100000f;
            //        yearSalary.transform.localScale = new Vector3(0.4f, 0.035f, 0.4f);
            //        maxScale = new Vector3(0.01f, myplayerList.player[i].YearSalaryScale, 0.01f);
            //        StartCoroutine(RepeatLerping(yearSalary, minScale, maxScale, scalingDuration));
            //        //yearSalary.transform.GetChild(0).transform.localScale = new Vector3(0.01f, myplayerList.player[i].YearSalaryScale, 0.01f);
            //        yearSalary.transform.localPosition = new Vector3(x, 0, z);
            //        yearSalary.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = colorpalatte;
            //        x += 2f;
            //    }
            //    myplayerList.player[i].MonthlySalary = int.Parse(data[6 * (i + 1) + 3]);
            //    if (myplayerList.player[i].MonthlySalary != 0)
            //    {
            //        var monthlySalary = Instantiate(graph_Bar);
            //        monthlySalary.transform.SetParent(Graph_Parent.transform);
            //        myplayerList.player[i].MonthlySalaryScale = (myplayerList.player[i].MonthlySalary - 1800) / 100000f;
            //        monthlySalary.transform.localScale = new Vector3(0.4f, 0.035f, 0.4f);
            //        maxScale = new Vector3(0.01f, myplayerList.player[i].MonthlySalaryScale, 0.01f);
            //        StartCoroutine(RepeatLerping(monthlySalary, minScale, maxScale, scalingDuration));
            //        //monthlySalary.transform.GetChild(0).transform.localScale = new Vector3(0.01f, myplayerList.player[i].MonthlySalaryScale, 0.01f);
            //        monthlySalary.transform.localPosition = new Vector3(x, 0, z);
            //        monthlySalary.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = colorpalatte;
            //        x += 2f;
            //    }
            //    myplayerList.player[i].LeaveBalance = int.Parse(data[6 * (i + 1) + 4]);
            //    if (myplayerList.player[i].LeaveBalance != 0)
            //    {
            //        var leaveBalance = Instantiate(graph_Bar);
            //        leaveBalance.transform.SetParent(Graph_Parent.transform);
            //        myplayerList.player[i].LeaveBalanceScale = (myplayerList.player[i].LeaveBalance / 20f);
            //        leaveBalance.transform.localScale = new Vector3(0.4f, 0.035f, 0.4f);
            //        maxScale = new Vector3(0.01f, myplayerList.player[i].LeaveBalanceScale, 0.01f);
            //        StartCoroutine(RepeatLerping(leaveBalance, minScale, maxScale, scalingDuration));
            //        //leaveBalance.transform.GetChild(0).transform.localScale = new Vector3(0.01f, myplayerList.player[i].LeaveBalanceScale, 0.01f);
            //        leaveBalance.transform.localPosition = new Vector3(x, 0, z);
            //        leaveBalance.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = colorpalatte;
            //        x += 2f;
            //    }
            //    myplayerList.player[i].TotalLeave = int.Parse(data[6 * (i + 1) + 5]);
            //    if (myplayerList.player[i].TotalLeave != 0)
            //    {
            //        var totalLeave = Instantiate(graph_Bar);
            //        totalLeave.transform.SetParent(Graph_Parent.transform);
            //        myplayerList.player[i].TotalLeaveScale = 1f;
            //        totalLeave.transform.localScale = new Vector3(0.4f, 0.035f, 0.4f);
            //        maxScale = new Vector3(0.01f, myplayerList.player[i].TotalLeaveScale, 0.01f);
            //        StartCoroutine(RepeatLerping(totalLeave, minScale, maxScale, scalingDuration));
            //        //totalLeave.transform.GetChild(0).transform.localScale = new Vector3(0.01f, myplayerList.player[i].TotalLeaveScale, 0.01f);
            //        totalLeave.transform.localPosition = new Vector3(x, 0, z);
            //        totalLeave.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = colorpalatte;
            //        x += 2f;
            //    }

            //    if (x > 4)
            //    {
            //        x = -4f;
            //        z += 1f;
            //    }

            //    j++;
            //}
        }
    }


    public void BubbleCreate(Color colorpalatte, int i)
    {

        var Bubble = Instantiate(BubblePrefeb);
        Bubble.transform.SetParent(BubbleContainer[i].transform);
        BubbleContainer[i].transform.GetChild(0).transform.GetComponent<BubbleScript>().ID = i;
        BubbleContainer[i].transform.GetChild(0).transform.GetComponent<BubbleScript>()._color = colorpalatte;
        //Debug.Log(BubbleContainer[i].transform.GetChild(0).transform.name);
        BubbleContainer[i].transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
        BubbleContainer[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetComponent<TextMeshPro>().text = myplayerList.player[i].name;
        BubbleContainer[i].transform.GetChild(0).transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = colorpalatte;

    }


    public void GraphGenerate(int ID, Color _color, string EmpName)
    {

        for (int i = 0; i < tableSize; i++)
        {
            if (z <= 4.5)
            {
                if (Zpos.Contains(z))
                {
                    z += 1f;
                }
                else
                {
                    if (i == ID)
                    {
                        Zpos.Add(z);
                        if (myplayerList.player[i].Year != 0)
                        {
                            myplayerList.player[i].YearScale = 0.75f;
                            var year = Instantiate(graph_Bar);
                            var emp_name = Instantiate(Emp_Name);
                            emp_name.transform.SetParent(Graph_Parent.transform);
                            emp_name.transform.localPosition = new Vector3(x-2, 1, z);
                            emp_name.transform.localScale = new Vector3(1, 1, 1);
                            emp_name.transform.GetComponent<TextMeshPro>().text = EmpName;
                            year.transform.SetParent(Graph_Parent.transform);
                            year.transform.localScale = new Vector3(0.4f, 0.035f, 0.4f);
                            maxScale = new Vector3(0.01f, myplayerList.player[i].YearScale, 0.01f);
                            StartCoroutine(RepeatLerping(year, minScale, maxScale, scalingDuration));
                            year.transform.localPosition = new Vector3(x, 0, z);
                            year.transform.GetComponent<Graph_BarScript>().ID = ID;
                            year.transform.GetComponent<Graph_BarScript>().Z_position = z;
                            year.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = _color;
                            year.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TextMeshPro>().text = myplayerList.player[i].Year.ToString();
                            x += 2f;
                        }

                        if (myplayerList.player[i].YearSalary != 0)
                        {
                            myplayerList.player[i].YearSalaryScale = (myplayerList.player[i].YearSalary / 12) / 100000f;
                            var yearSalary = Instantiate(graph_Bar);
                            yearSalary.transform.SetParent(Graph_Parent.transform);
                            yearSalary.transform.localScale = new Vector3(0.4f, 0.035f, 0.4f);
                            maxScale = new Vector3(0.01f, myplayerList.player[i].YearSalaryScale, 0.01f);
                            StartCoroutine(RepeatLerping(yearSalary, minScale, maxScale, scalingDuration));
                            yearSalary.transform.localPosition = new Vector3(x, 0, z);
                            yearSalary.transform.GetComponent<Graph_BarScript>().ID = ID;
                            yearSalary.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = _color;
                            yearSalary.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TextMeshPro>().text = myplayerList.player[i].YearSalary.ToString();
                            x += 2f;
                        }

                        if (myplayerList.player[i].MonthlySalary != 0)
                        {
                            myplayerList.player[i].MonthlySalaryScale = (myplayerList.player[i].MonthlySalary - 1800) / 100000f;
                            var monthlySalary = Instantiate(graph_Bar);
                            monthlySalary.transform.SetParent(Graph_Parent.transform);
                            monthlySalary.transform.localScale = new Vector3(0.4f, 0.035f, 0.4f);
                            maxScale = new Vector3(0.01f, myplayerList.player[i].MonthlySalaryScale, 0.01f);
                            StartCoroutine(RepeatLerping(monthlySalary, minScale, maxScale, scalingDuration));
                            monthlySalary.transform.localPosition = new Vector3(x, 0, z);
                            monthlySalary.transform.GetComponent<Graph_BarScript>().ID = ID;
                            monthlySalary.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = _color;
                            monthlySalary.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TextMeshPro>().text = myplayerList.player[i].MonthlySalary.ToString();
                            x += 2f;
                        }

                        if (myplayerList.player[i].LeaveBalance != 0)
                        {
                            myplayerList.player[i].LeaveBalanceScale = (myplayerList.player[i].LeaveBalance / 20f);
                            var leaveBalance = Instantiate(graph_Bar);
                            leaveBalance.transform.SetParent(Graph_Parent.transform);
                            leaveBalance.transform.localScale = new Vector3(0.4f, 0.035f, 0.4f);
                            maxScale = new Vector3(0.01f, myplayerList.player[i].LeaveBalanceScale, 0.01f);
                            StartCoroutine(RepeatLerping(leaveBalance, minScale, maxScale, scalingDuration));
                            leaveBalance.transform.localPosition = new Vector3(x, 0, z);
                            leaveBalance.transform.GetComponent<Graph_BarScript>().ID = ID;
                            leaveBalance.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = _color;
                            leaveBalance.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TextMeshPro>().text = myplayerList.player[i].LeaveBalance.ToString();
                            x += 2f;
                        }

                        if (myplayerList.player[i].TotalLeave != 0)
                        {
                            myplayerList.player[i].TotalLeaveScale = 1f;
                            var totalLeave = Instantiate(graph_Bar);
                            totalLeave.transform.SetParent(Graph_Parent.transform);
                            totalLeave.transform.localScale = new Vector3(0.4f, 0.035f, 0.4f);
                            maxScale = new Vector3(0.01f, myplayerList.player[i].TotalLeaveScale, 0.01f);
                            StartCoroutine(RepeatLerping(totalLeave, minScale, maxScale, scalingDuration));
                            totalLeave.transform.localPosition = new Vector3(x, 0, z);
                            totalLeave.transform.GetComponent<Graph_BarScript>().ID = ID;
                            totalLeave.transform.GetChild(0).transform.GetComponent<MeshRenderer>().material.color = _color;
                            totalLeave.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TextMeshPro>().text = myplayerList.player[i].TotalLeave.ToString();
                            x += 2f;
                        }

                    }

                    if (x > 4)
                    {
                        x = -4f;
                        z += 1f;
                    }
                }
            }
            else
            {
                z = -4.5f;
            }
        }


    }


    public void RemoveFromGraph(int ID,string EmpName)
    {
        // Debug.Log("Removing from Graph");
        Transform[] Children = transform.GetChild(0).transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < Children.Length; i++)
        {
            if (Children[i].tag == "Graph_Bar")
            {
                if (Children[i].transform.GetComponent<Graph_BarScript>().ID == ID)
                {
                    var name = Children[i].gameObject.transform.name;
                    removingbar = Children[i].gameObject;
                    maxScale = Children[i].transform.GetChild(0).transform.localScale;
                    StartCoroutine(RemoveGraphBar(removingbar, maxScale, minScale, scalingDuration));
                    Debug.Log(name + " : " + Children[i].transform.GetComponent<Graph_BarScript>().ID + " : " + maxScale);
                }
            }


            if (Children[i].tag == "Emp_Name")
            {
                if (Children[i].transform.GetComponent<TextMeshPro>().text == EmpName)
                {
                    removingbar = Children[i].gameObject;
                    Destroy(removingbar);
                }
            }
        }
        //foreach (Transform child in Children)
        //{
        //    //var ID = child.gameObject.transform.GetComponents<Graph_Bar>().
        //    var name = child.gameObject.transform.name;
        //    Debug.Log(name);
        //}
    }


    IEnumerator RepeatLerping(GameObject clone, Vector3 startScale, Vector3 endScale, float time)
    {
        float t = 0.0f;
        float rate = (1f / time) * scalingSpeed;
        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            //Debug.Log(clone.transform.localScale);
            clone.transform.GetChild(0).transform.localScale = Vector3.Lerp(startScale, endScale, t);
            //Debug.Log("RepeatLerping");
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
    }




    IEnumerator RemoveGraphBar(GameObject clone, Vector3 endScale, Vector3 startScale, float time)
    {
        float t = 0.0f;
        float rate = (1f / time) * scalingSpeed;
        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            Debug.Log(clone.transform.localScale);
            clone.transform.GetChild(0).transform.localScale = Vector3.Lerp(endScale, startScale, t);
            Debug.Log("RepeatLerping");
            yield return null;
        }
        if (Zpos.Contains(clone.transform.localPosition.z))
        {
            Zpos.Remove(clone.transform.localPosition.z);
            z = -4.5f;
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(clone);
    }

    public void UpdateXZPositions()
    {

    }


}



