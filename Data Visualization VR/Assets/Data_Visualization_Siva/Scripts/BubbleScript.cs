using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleScript : MonoBehaviour
{
    public bool initialPosition;
    public int ID;
    public Color _color;
    public bool _alreadyinGraph;
    public Material _outofData;
    public Material _fullofData;
    public GameManager _gameManager;
    public bool isCollidable = true;

    public ReadCSV _readCSVManager;

    public string EmpName;
    public Vector3 initialPos;
    public float _speed;

    private bool play = true;
    private bool woosh = true;
    // Start is called before the first frame update
    void Start()
    {
        _fullofData = transform.GetChild(0).transform.GetComponent<MeshRenderer>().material;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _readCSVManager = GameObject.Find("Graph").GetComponent<ReadCSV>();
        EmpName = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshPro>().text;

    }

    // Update is called once per frame
    void Update()
    {
        if (initialPosition)
        {
            if (woosh == true)
            {
                _gameManager.WooshSoundEFX();
                woosh = false;
            }

            if (this.gameObject.transform.localPosition.x == 0 && this.gameObject.transform.localPosition.y == 0)
            {
                initialPosition = false;
                woosh = true;
            }
            Debug.Log("Moving");
            transform.localPosition = Vector3.MoveTowards(this.gameObject.transform.localPosition, initialPos, _speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Graph")
        {
            if (isCollidable == true)
            {
                _gameManager.Ball_Graph_interactionSoundEFX();

            }
        }


        if (other.name == "PinchArea")
        {
            if (play == true)
            {
                _gameManager.Ball_PickSoundEFX();
                play = false;
                StartCoroutine(PlaySoundEFXDelay());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
        initialPosition = true;

        if (other.name == "Graph")
        {
            if (isCollidable == true)
            {
                //_gameManager.Ball_Graph_interactionSoundEFX();

                if (_alreadyinGraph == false)
                {
                    if (_readCSVManager.Zpos.Count <= 9)
                    {
                        _gameManager.CreateGraphBar(ID, _color,EmpName);
                        transform.GetChild(0).transform.GetComponent<MeshRenderer>().material = _outofData;
                        _alreadyinGraph = true;
                    }

                }
                else if (_alreadyinGraph == true)
                {
                    Debug.Log("Already inside the Graph");
                    _gameManager.RemoveGraph(ID, EmpName);
                    transform.GetChild(0).transform.GetComponent<MeshRenderer>().material = _fullofData;
                    _alreadyinGraph = false;
                }
                isCollidable = false;
                StartCoroutine(EnableCollidable());
            }
        }

    }


    IEnumerator EnableCollidable()
    {
        yield return new WaitForSeconds(1.5f);
        isCollidable = true;
    }

    IEnumerator PlaySoundEFXDelay()
    {
        yield return new WaitForSeconds(1.0f);
        play = true;
    }
}
