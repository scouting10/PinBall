using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるZ軸の最大値
    private float visiblePosZ = -8.0f;
    public GameObject director;
    private GameObject gameoverText;
    

    // Use this for initialization
    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.gameoverText = GameObject.Find("GameOverText");
        
    }


    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.SetActive(true);
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

            //左右キーを押すとコンティニュー処理
            
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(3, 3, 4);
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameoverText.SetActive(false);
                //スコアの初期化どうやる？
                this.director.GetComponent<GameDirector>().Scorereset();
            }
        }

        
    }


   //この下は、BrightnessRegulator2ではコメントアウト
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.director.GetComponent<GameDirector>().HitSmallStar();

        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.director.GetComponent<GameDirector>().HitLargeStar();

        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.director.GetComponent<GameDirector>().HitSmallCloud();
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.director.GetComponent<GameDirector>().HitLargeCloud();
        }
        
    }
   
}
        
	
	

