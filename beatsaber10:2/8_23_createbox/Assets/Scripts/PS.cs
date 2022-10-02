using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS : MonoBehaviour
{

    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     // 当たった相手の色をランダムに変える
	// 	other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    // }

    /// <summary>
	/// パーティクルが他のGameObject(Collider)に当たると呼び出される
	/// </summary>
	/// <param name="other"></param>
	private void OnParticleCollision(GameObject other)
	{
		// 当たった相手の色をランダムに変える
		//other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        //other.GetComponent<Collider>().isTrigger = false;
        //if(other.gameObject.name == "Icube"){
            Destroy(other.gameObject);
        //}
	}
}
