using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxDialogue : MonoBehaviour
{
    public GameObject Box;
    public Animator animator;
    public TMP_Text popUpBox;

    public void PopUp(string text)
    {
        Box.SetActive(true);
        popUpBox.text = text;
        animator.SetTrigger("pop");

    }
}