using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInteraction : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject spawnedOBJ;
    public Touchcontrols objenable;

    public GameObject _Hologram;

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

        if (this.gameObject.name == "IPAD")
        {
            Debug.Log(this.gameObject.name + " : " + other.gameObject.name);
            if (other.gameObject.name == "tip")
            {
                spawnedOBJ.SetActive(true);
                objenable.ObjectEnabled = true;
            }
        }

        if (this.gameObject.name == "Tip Swipe")
        {
            Debug.Log(this.gameObject.name + " : " + other.gameObject.name);
            if (other.gameObject.name == "tip")
            {
                _Hologram.SetActive(true);
                if (play == true)
                {
                    _gameManager.Graph_BottomSoundEFX();
                    play = false;
                    StartCoroutine(PlaySoundEFXDelay());
                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.name == "IPAD")
        {
            if (other.gameObject.name == "tip")
            {
                objenable.ObjectEnabled = false;
                //spawnedOBJ.transform.position = new Vector3(0, 0, 0);
                spawnedOBJ.SetActive(false);
            }
        }

        if (this.gameObject.name == "Tip Swipe")
        {
            if (other.gameObject.name == "tip")
            {
                _gameManager.EnableBubble();
            }
        }
    }

    IEnumerator PlaySoundEFXDelay()
    {
        yield return new WaitForSeconds(1.0f);
        play = true;
    }
}
