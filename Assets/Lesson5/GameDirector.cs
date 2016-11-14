using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

    private GameObject scoreText;
    int score = 0;

    public void HitLargeCloud()
    {
        this.score += 500;
    }

    public void HitSmallCloud()
    {
        this.score += 50;
    }

    public void HitLargeStar()
    {
        this.score += 100;
    }

    public void HitSmallStar()
    {
        this.score += 10;
    }

    public void Scorereset()
    {
        this.score = 0;
    }


	// Use this for initialization
	void Start () {
        this.scoreText = GameObject.Find("ScoreText");
	
	}
	
	// Update is called once per frame
	void Update () {
        this.scoreText.GetComponent<Text>().text =
            this.score.ToString();
	}
    
}
