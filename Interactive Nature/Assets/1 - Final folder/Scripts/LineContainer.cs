using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineContainer : MonoBehaviour
{

    public void ChangeSpacing()
    {
        string Text = transform.GetComponentInChildren<Text>().ToString();
        Debug.Log(Text.ToString());
        float numberOfChars = Text.Length;
        float charPerLine = 24f;
        float lines = Mathf.Ceil(numberOfChars / charPerLine);
        int spacing = (Mathf.RoundToInt(lines) * -50) - 50;
        GetComponent<VerticalLayoutGroup>().padding.bottom = spacing;
    }
}
