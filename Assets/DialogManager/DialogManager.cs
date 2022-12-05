using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Dialog[] dialogs;

    private void Awake()
    {
        foreach (Dialog currentDialog in dialogs)
        {
            int dialogCount = 0;
            GameObject dialog =  Instantiate(
                original: currentDialog.dialogPrefab, 
                position: GameObject.FindGameObjectWithTag("Canvas").transform.position, 
                rotation: Quaternion.identity, 
                parent: GameObject.FindGameObjectWithTag("Canvas").transform);
            dialogCount++;
            dialog.name = "PersonPanelFormat[" + dialogCount + "]";

            if(currentDialog.jumlahCharacter == 3)
            {
                GameObject characterSatu = Instantiate(
                     original: currentDialog.characterSatu.characterPrefab,
                     position: GameObject.FindGameObjectWithTag("CharacterList").transform.position,
                     rotation: Quaternion.identity,
                     parent: GameObject.FindGameObjectWithTag("CharacterList").transform);
                characterSatu.name = "Character-" + 1;
                characterSatu.GetComponent<Image>().sprite = currentDialog.characterSatu.characterImage;

                GameObject characterDua = Instantiate(
                     original: currentDialog.characterDua.characterPrefab,
                     position: GameObject.FindGameObjectWithTag("CharacterList").transform.position,
                     rotation: Quaternion.identity,
                     parent: GameObject.FindGameObjectWithTag("CharacterList").transform);
                characterDua.name = "Character-" + 2;
                characterDua.GetComponent<Image>().sprite = currentDialog.characterDua.characterImage;

                GameObject characterTiga = Instantiate(
                     original: currentDialog.characterTiga.characterPrefab,
                     position: GameObject.FindGameObjectWithTag("CharacterList").transform.position,
                     rotation: Quaternion.identity,
                     parent: GameObject.FindGameObjectWithTag("CharacterList").transform);
                characterTiga.name = "Character-" + 3;
                characterTiga.GetComponent<Image>().sprite = currentDialog.characterTiga.characterImage;
            }
            else if(currentDialog.jumlahCharacter == 2)
            {
                GameObject characterSatu = Instantiate(
                     original: currentDialog.characterSatu.characterPrefab,
                     position: GameObject.FindGameObjectWithTag("CharacterList").transform.position,
                     rotation: Quaternion.identity,
                     parent: GameObject.FindGameObjectWithTag("CharacterList").transform);
                characterSatu.name = "Character-" + 1;
                characterSatu.GetComponent<Image>().sprite = currentDialog.characterSatu.characterImage;

                GameObject characterDua = Instantiate(
                     original: currentDialog.characterDua.characterPrefab,
                     position: GameObject.FindGameObjectWithTag("CharacterList").transform.position,
                     rotation: Quaternion.identity,
                     parent: GameObject.FindGameObjectWithTag("CharacterList").transform);
                characterDua.name = "Character-" + 2;
                characterDua.GetComponent<Image>().sprite = currentDialog.characterDua.characterImage;
            } else if(currentDialog.jumlahCharacter == 1)
            {
                GameObject characterSatu = Instantiate(
                     original: currentDialog.characterSatu.characterPrefab,
                     position: GameObject.FindGameObjectWithTag("CharacterList").transform.position,
                     rotation: Quaternion.identity,
                     parent: GameObject.FindGameObjectWithTag("CharacterList").transform);
                characterSatu.name = "Character-" + 1;
                characterSatu.GetComponent<Image>().sprite = currentDialog.characterSatu.characterImage;
            }


            // var charactersList = currentDialog.charactersList;
            // foreach (DialogCharacter currentCharacter in charactersList)
            // {
            // int characterCount = 1;
            // currentDialog.characterNameText.text = currentCharacter.characterName;
            // if (characterCount != currentDialog.jumlahCharacter)
            // {
            // GameObject character = Instantiate(
            //original: currentCharacter.characterPrefab,
            //position: GameObject.FindGameObjectWithTag("CharacterList").transform.position,
            //: Quaternion.identity,
            //: GameObject.FindGameObjectWithTag("CharacterList").transform);
            //character.name = "Character-" + characterCount;
            //character.GetComponent<Image>().sprite = currentCharacter.characterImage;
            //}
            //break;
            //}
        }
    }

    public void dialogDisplay()
    {

    }
}
