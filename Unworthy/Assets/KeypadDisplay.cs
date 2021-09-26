using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadDisplay : MonoBehaviour
{
    public Text displayText;

    Queue<string> nums = new Queue<string>(4);
    int clearCount;

    // Start is called before the first frame update
    void Start()
    {
        Text t = displayText.GetComponent<Text>();
        t.text = "----";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton(Button b)
    {
        Text t = b.GetComponentInChildren<Text>();
        if (displayText.text == "----")
        {
            //displayText.text = "";
            displayText.text = "";
        }

        if (nums.Count < 4)
        {
            if (t.text == "Enter")
            {
                nums.Peek();
                while (nums.Count > 0)
                {
                    string n = nums.Dequeue().ToString();

                }
            }

            if (t.text == "C" && clearCount == 0)
            {
                clearCount++;
                nums.Dequeue();
            }
            else if (t.text == "C" && clearCount == 1)
            {
                clearCount--;
                ClearDisplay();
            }
            else
            {
                nums.Enqueue(t.text);
                displayText.text += t.text;
            }
        }
        else
        {
            if (t.text == "C" && clearCount == 0)
            {
                clearCount++;
                nums.Dequeue();
                displayText.text.Remove(displayText.text.Length);
            }
            else if (t.text == "C" && clearCount == 1)
            {
                clearCount--;
                ClearDisplay();
            }
        }

        foreach (string n in nums)
        {

        }
        //for (int i = 0; i < nums.Count; i++)
        //{
            //string num = nums.Dequeue();
            //displayText.text += num;
            //Debug.Log("Display text: " + displayText.text);
        //}
        //displayText.text = nums.Peek();
        //Debug.Log("Display Text: " + displayText.text);
        Debug.Log("Queue: " + nums.Count);
        // makes sure that only if clear is pressed twice consecutively, the whole queue will be dequeued
        clearCount = 0;
    }

    public void ClearDisplay()
    {
        while (nums.Count > 0)
        {
            nums.Dequeue();
        }
    }
}
