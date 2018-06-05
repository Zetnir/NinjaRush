using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScript : MonoBehaviour {

    public Button Pause;

    public Text Score;

    public List<Image> Heart;

    private string score_;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        UpdateUiScore();
    }

    public string GetScore()
    {
        return score_;
    }

    public void SetScore(int score)
    {
        this.score_ = score.ToString() + "m";
    }

    public void UpdateUiScore()
    {
        Score.text = score_;
    }

    public void LoseHP()
    {
        for(int i =0; i <Heart.Count; i++)
        {
            if(Heart[i].gameObject.activeSelf)
            {
                Heart[i].gameObject.SetActive(false);
                break;
            }
        }
    }

    public void ResetHP()
    {
        for (int i = 0; i < Heart.Count; i++)
        {
            Heart[i].gameObject.SetActive(true);
        }

    }

}
