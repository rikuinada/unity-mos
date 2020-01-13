using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// アニメーション簡易プレビュースクリプト
// 2015/4/25 quad arrow
//

// Require these components when using this script
[RequireComponent(typeof(Animator))]

public class TrainingChanger : MonoBehaviour
{

	private Animator anim;						// Animatorへの参照
	private bool updateFlag = false;
	double calorie;
	bool movement;
	private Vector3 dir;

	const float updateSpeed = 30.0f;

	float AccelerometerUpdateInterval = 1.0f / updateSpeed;
	float LowPassKernelWidthInSeconds = 1.0f;
	float LowPassFilterFactor = 0;
	Vector3 lowPassValue = Vector3.zero;

	// Use this for initialization
	void Start ()
	{
		// 各参照の初期化
		anim = GetComponent<Animator> ();
	}

	void Update()
    {
		// ↑キー/スペースが押されたら”走る”動作
		if (Input.GetKeyDown("up"))
		{
			// ブーリアンNextをtrueにする
			anim.SetBool("Run", true);
			updateFlag = true;

		}
		//↑キー / スペースが押されたら”走る”を中止
		if (Input.GetKeyDown("down"))
		{
			// ブーリアンNextをtrueにする
			anim.SetBool("Run", false);
			updateFlag = false;
		}


		if (updateFlag)
        {
			calorie = InputInfoManager.getCalorie();
			InputInfoManager.updateCalorie(calorie - 0.01);
		}

        //　y-z平面上だとダンベルカール
        if (MyAcceleration.getMotion())
        {
			anim.SetBool("Run", true);
			updateFlag = true;
        }
        else
        {
			// ブーリアンNextをtrueにする
			anim.SetBool("Run", false);
			updateFlag = false;
		}
	}


	Vector3 filterAccelValue(bool smooth)
	{
		return Vector3.Lerp(lowPassValue, MyAcceleration.getDir(), LowPassFilterFactor);
	}

}
