using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{

    // private float beat = ( 60 / 130 ) * 2;
    // private float timer = 0;
    // CubeプレハブをGameObject型で取得

    //倒したときのエフェクト
    public GameObject breakEffect;

    public GameObject cube;
    List<GameObject> L_cube = new List<GameObject>();
    GameObject[] cubes = new GameObject[5];

    public static readonly int L_NUM = 20; //配列の大きさ

    // Start is called before the first frame update
    void Start()
    {
        // for(int i=0; i<L_NUM; i++){
        //     L_cube.Add(Instantiate (cube, new Vector3(0.0f + Random.Range(-5, 5),0.0f, 0.0f), Quaternion.identity));  
        //     L_cube[i].SetActive(false);   
        // }
    }

    // Update is called once per frame
    int i = 0;
    int effect_flag = 0;
    void Update()
    {
        
        // if(L_NUM > i){
        //     if(effect_flag == 0){ //エフェクトを一回きり出現させる
        //         GenerateEffect();
        //         effect_flag = 1;
        //     }
        //     L_cube[i].SetActive(true);  
        //     L_cube[i].transform.position += Time.deltaTime * transform.forward * 20;
        //     if(L_cube[i].transform.position.z > 20){
        //         //L_cube[i].SetActive(false);  
        //         i++;
        //         effect_flag--;
        //     }
        // }

        if(i >= 200){
            i -= 200;
            //GenerateEffect();
            GameObject Icube = Instantiate (cube, new Vector3(0.0f + Random.Range(-5, 5),0.0f, 0.0f), Quaternion.identity);  
        }
        i++;
    }

        //エフェクトを生成する
    void GenerateEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = L_cube[i].transform.position;
    }

}
