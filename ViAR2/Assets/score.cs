using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    int points;
    public TMP_Text txt;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = points.ToString();
    }

    public void oneMore() {
        points = points + 1;
    }
}
