using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineContainer : MonoBehaviour
{
    Swiper swiper;
    private void Start()
    {
        swiper = FindObjectOfType<Swiper>();
    }

    //resizing the containers of information text dependent on the size of the text

    void Update()
    {
        if(swiper.currentPage == 3)
        {
            string Text = gameObject.transform.GetChild(0).GetComponent<Text>().text;
            float numberOfChars = Text.Length;
            float charPerLine = 24f;
            float lines = Mathf.Ceil(numberOfChars / charPerLine);
            int spacing = (Mathf.RoundToInt(lines) * -50) +50;
            GetComponent<VerticalLayoutGroup>().padding.bottom = spacing;
        }
    }
}
