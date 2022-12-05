using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialog
{
    [Header("Dialog Panel")]
    public GameObject dialogPrefab;

    [Header("Character")]
    [Range(1, 3)]
    public int jumlahCharacter;
    public TMP_Text characterNameText;
    //public List<DialogCharacter> characterList = new List<DialogCharacter>(3);
    public DialogCharacter characterSatu;
    public DialogCharacter characterDua;
    public DialogCharacter characterTiga;    

    [Header("Dialog")]
    public TMP_Text dialogText;
    [TextArea(minLines: 2, maxLines: 6)]
    public string dialog;

    [Header("Button")]
    public DialogButton[] button;
}
