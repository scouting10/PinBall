using UnityEngine;
using System.Collections;

public class FripperControllerTouch : MonoBehaviour
{
    //Hingijointコンポネントを入れる
    private HingeJoint myHingeJoynt;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HinjiJointコンポーネント取得
        this.myHingeJoynt = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {
        //タッチ座標や中央座標の変数
        Vector2 touchPos = Input.GetTouch(0).position;
        Vector2 centerPos = new Vector2(0f, 0f);
        float judge = touchPos.x + centerPos.x;

        //画面左をタップした左フリッパーを動かす
        if (judge<0 && Input.GetTouch(0).phase == TouchPhase.Began && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        
        //右フリッパー動かす
        if (judge>0 && Input.GetTouch(0).phase == TouchPhase.Began && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //指を離すとフリッパーを元に戻す.テキスト通りにやると、片方を上げっぱなしにできない。
        if (judge<0 && Input.GetTouch(0).phase == TouchPhase.Ended && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (judge>0 && Input.GetTouch(0).phase == TouchPhase.Ended && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoynt.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoynt.spring = jointSpr;
    }
}