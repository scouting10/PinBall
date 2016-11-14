using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
    //Hingijointコンポネントを入れる
    private HingeJoint myHingeJoynt;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;
    
	// Use this for initialization
	void Start () {
        //HinjiJointコンポーネント取得
        this.myHingeJoynt = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	
	}
	
	// Update is called once per frame
	void Update () {

        //矢印キーをしたとき左フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.LeftArrow)&& tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右フリッパー動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離すとフリッパーを元に戻す.テキスト通りにやると、片方を上げっぱなしにできない。
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag=="LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)&& tag=="RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoynt.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoynt.spring = jointSpr;
    }
}