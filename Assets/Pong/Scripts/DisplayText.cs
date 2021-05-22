using TMPro;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text comboText;
    //public TMP_Text nowPlaying;
    
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
        comboText.text = "Combo: " + GameManager.Instance.currCombo;
        //nowPlaying.text = "Score: " + GameManager.Instance.score;
    }
}
