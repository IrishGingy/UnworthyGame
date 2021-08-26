using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note01 : MonoBehaviour
{
    public Item item;

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject UINote;
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
        rend = note.GetComponent<Renderer>();
        rend.material = materials[mat];
    }

    // Update is called once per frame
    void Update()
    {
        // Referencing other script's DistanceFromTarget variable.
        TheDistance = PlayerCasting.DistanceFromTarget;

        if (readingNote)
        {
            if (Input.GetKeyDown(KeyCode.A) && mat > 0)
            {
                mat--;
                rend.material = materials[mat];
            }
            if (Input.GetKeyDown(KeyCode.D) && mat < materials.Length - 1)
            {
                mat++;
                rend.material = materials[mat];
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                readingNote = false;
                ThePlayer.SetActive(true);
                NoteCam.SetActive(false);
                UINote.SetActive(false);

                bool wasPickedUp = Inventory.instance.Add(item);
                if (wasPickedUp)
                {
                    Destroy(note);
                }
                //ActionDisplay.SetActive(true);
                //ActionText.SetActive(true);
            }
        }
    }

    private void OnMouseOver()
    {
        if (!readingNote)
        {
            if (TheDistance <= 3)
            {
                //rend.material = materials[1];

                if (Input.GetKeyDown(KeyCode.E))
                {
                     ReadingNote();
                }
            }
        }
    }

    private void OnMouseExit()
    {
        //rend.material = materials[0];

        //ActionDisplay.SetActive(false);
        //ActionText.SetActive(false);
    }

    private void ReadingNote()
    {
        //rend.material = materials[0];
        readingNote = true;

        //ActionDisplay.SetActive(false);
        //ActionText.SetActive(false);
        UINote.SetActive(true);
        NoteCam.SetActive(true);
        ThePlayer.SetActive(false);
    }
}