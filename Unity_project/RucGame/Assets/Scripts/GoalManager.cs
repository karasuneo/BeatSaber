using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityChan;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    //キャラクターを格納するための変数
    public GameObject player;
    //テキストを格納するための変数
    public GameObject text;

    //RestartManager型
    private RestartManager restart;

    //Goalしたかどうか判定する
    private bool isGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンス生成
        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {
        //Goalした後で画面をクリックされたとき
        if(isGoal && Input.GetMouseButton(0))
        {
            restart.Restart();
        }
    }

    //当たり判定関数
    private void OnTriggerEnter(Collider other)
    {
        //当たってきたオブジェクトの名前が対象キャラクターの名前と同じ時
        if(other.name == player.name)
        {
            // //一旦ログに出力
            // Debug.Log("キャラクターと接触しました！");
            //上記のテキストの内容を変更する
            text.GetComponent<TextMeshProUGUI>().text = "Goal!!!";
            //テキストをオンにして非表示->表示にする
            text.SetActive(true);

            //ユニティちゃんを動けなくする
            player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
            //アニメーションをオフにする
            player.GetComponent<Animator>().enabled = false;

            //Goal判定をTrueにする
            isGoal = true;
        }
    }

}