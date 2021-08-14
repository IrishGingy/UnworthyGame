using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note01 : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject UINote;
    public GameObject ThePlayer;
    public GameObject NoteCam;

    // Update is called once per frame
    void Update()
    {
        // Referencing other script's DistanceFromTarget variable.
        TheDistance = PlayerCasting.DistanceFromTarget;

        if (NoteCam.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ThePlayer.SetActive(true);
                NoteCam.SetActive(false);
                UINote.SetActive(false);
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
            }
        }
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (TheDistance <= 3)
            {
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                UINote.SetActive(true);
                NoteCam.SetActive(true);
                ThePlayer.SetActive(false);
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

}