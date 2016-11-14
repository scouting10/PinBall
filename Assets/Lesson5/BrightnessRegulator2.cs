using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrightnessRegulator2 : MonoBehaviour
{
    //Materialを入れる
    Material myMaterial;

    //Emissionの最小値
    private float minEmission = 0.3f;
    //Emissionの強度
    private float magEmission = 2.0f;
    //　角度
    private int degree = 0;
    // 発光速度
    private int speed = 10;
    // ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    //点数処理。GameObjectの箱用意。
    private GameObject scoreText;
    //後の処理で、textには変数scoreを入れる。０で初期化
    private int score = 0;
    //以下のtagのところでscoreを使うと、衝突のたびにscoreが加算せず、単に「そのオブジェクトに設定した点数に切り替わる」だけだったので、pointという変数を新しく作る。
    private int point;
    


    // Use this for initialization
    void Start()
    {

        //タグによって光らせる色を変える
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
            point = 10;

        }
        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
            point = 100;

        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.blue;
            point = 500;

        }

        //オブジェクトにアタッチしているMaterial を取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);


        //スコア用のGameobjectを取得
        this.scoreText = GameObject.Find("ScoreText");
        this.scoreText.GetComponent<Text>().text =
            this.score.ToString();
        
/*
                Text score = this.scoreText.GetComponent<Text>();
                int currentScore=int.Parse(score.text);
                int targetScore = currentScore + this.score;
                this.scoreText.GetComponent<Text>().text =
                    targetScore.ToString();
        */

    }

    // Update is called once per frame
    void Update()
    {

        if (this.degree >= 0)
        {
            //光らせる強度を計算する
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            //エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            this.degree -= this.speed;

        }

    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 100;

        //スコアを更新
        //this.score = point;
        //this.scoreText.GetComponent<Text>().text =
        //  this.score.ToString();

        //Text score = this.scoreText.GetComponent<Text>();
        
        Text score = this.scoreText.GetComponent<Text>();
        int currentScore = int.Parse(score.text);
        int targetScore = currentScore+point;
        //int targetScore = currentScore + point;
        this.scoreText.GetComponent<Text>().text =
            targetScore.ToString();
    }
}