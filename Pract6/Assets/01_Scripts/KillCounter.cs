using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    int points = 0;
    public TMPro.TMP_Text counterText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowPoints();
    }

    private void ShowPoints(){
        counterText.text = points.ToString();
    }

    public void TakePoints()
    {
        points++;
    }
}
