using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSound : MonoBehaviour
{
    public GameManager _gameManager;
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
        Debug.Log(other.name);
        if (other.name == "b_r_index3")
        {
            if (play == true)
            {
                _gameManager.PickupSoundEFX();
                play = false;
                StartCoroutine(PlaySoundEFXDelay());
            }
        }
    }


    IEnumerator PlaySoundEFXDelay()
    {
        yield return new WaitForSeconds(1.0f);
        play = true;
    }
}
