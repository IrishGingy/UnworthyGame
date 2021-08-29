using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Item item;

    public float TheDistance;
    public GameObject ThePlayer;
    public GameObject NoteCam;
    public GameObject note;
    public Material[] materials;
    public Canvas canvas;

    bool readingNote;
    Renderer rend;
    int mat = 0;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Referencing other script's DistanceFromTarget variable.
        TheDistance = PlayerCasting.DistanceFromTarget;

        if (readingNote)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                readingNote = false;
                ThePlayer.SetActive(true);
                NoteCam.SetActive(false);

                bool wasPickedUp = Inventory.instance.Add(item);
                if (wasPickedUp)
                {
                    Destroy(note);
                }
            }
        }
    }

    public void ReadingNote()
    {
        //rend.material = materials[0];
        readingNote = true;

        //ActionDisplay.SetActive(false);
        //ActionText.SetActive(false);
        NoteCam.SetActive(true);
        ThePlayer.SetActive(false);
    }
}