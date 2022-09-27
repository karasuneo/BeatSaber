using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;
using TMPro;
 
public class DeadWallController : MonoBehaviour
{
    //オブジェクトの速度
    public float speed = 0.05f;
    //オブジェクトの横移動の最大距離
    public float max_x = 10.0f;
 
    //ユニティちゃんを格納する変数
    public GameObject player;
    //テキストを格納する変数
    public GameObject text;
 
    //RestartManager型
    private RestartManager restart;
    
     // Start is called before the first frame update
    void Start()
    {
        //インスタンス生成
        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {
        //フレーム毎speedの値分だけx軸方向に移動する
        this.gameObject.transform.Translate(speed, 0, 0);
 
        //Transformのxの値が一定値を超えたときに向きを反対にする
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
            speed *= -1;
        }
 
        //ゲームオーバー状態で画面がクリックされたとき
        if(restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }
    }
 
    //ユニティちゃんとの当たり判定
    private void OnCollisionEnter(Collision other)
    {
        //接触したオブジェクトがユニティちゃんのとき
        if(other.gameObject.name == player.name)
        {
            restart.PrintGameOver();
        }
    }
}
