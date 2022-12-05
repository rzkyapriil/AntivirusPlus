using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriting : MonoBehaviour
{
	TMP_Text txt;
	//[TextArea(minLines:2, maxLines:6)]
	string story;

	void Awake()
	{
		txt = GetComponent<TMP_Text>();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.08f);
		}
	}

}
