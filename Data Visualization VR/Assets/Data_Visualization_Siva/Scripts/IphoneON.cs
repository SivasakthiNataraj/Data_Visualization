using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IphoneON : MonoBehaviour
{
    public GameManager _gameManager;
    public Animator _IphoneOn;
    private bool play = true;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.name == "tip")
        {
            if (play == true)
            {
                _gameManager.IpadONSoundEFX();
                play = false;
                _IphoneOn.Play("IpadON");
            }
            //Debug.Log("Playing");
        }
    }
}
