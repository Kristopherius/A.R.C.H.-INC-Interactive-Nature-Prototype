using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintDisabled : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    void Start()
    {
        if (PlayerPrefs.GetInt("Hint") > 0)
        {
            transform.gameObject.SetActive(false);
            button.SetActive(true);
        }
        else
        {
            transform.gameObject.SetActive(true);
            button.SetActive(false);
        }
    }
}
