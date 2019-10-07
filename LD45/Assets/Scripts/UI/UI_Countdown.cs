using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Countdown : MonoBehaviour
{
    [SerializeField] Color[] colors = new Color[4];

    [SerializeField] TextMeshProUGUI txt;

    public void UpdateText(int i)
    {
        txt.text = i.ToString();
        txt.color = colors[3 - i];
    }

    public void DisableText()
    {
        StartCoroutine(DisableObj());
    }

    IEnumerator DisableObj()
    {
        yield return new WaitForSeconds(1);

        txt.gameObject.SetActive(false);
    }
}
