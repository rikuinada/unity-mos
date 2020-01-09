using UnityEngine;
using System.Collections;

public class TitleMgr : MonoBehaviour {
  void OnGUI()
  {
    // フォントサイズ
    Util.SetFontSize(48);
    Util.SetFontColor(Color.white);
    // 中央揃え
    Util.SetFontAlignment(TextAnchor.MiddleCenter);

    // フォントの位置
    float w = 256; // 幅
    float h = 48; // 高さ
    float px = Screen.width / 2 - w / 2;
    float py = Screen.height / 2 - h / 2;

    // フォント描画
    Util.GUILabel(px, py, w, h, "Muscle × Technology");

    // ボタンは少し下にずらす
    py += 60;
    if (GUI.Button(new Rect(px, py, w, h), "START"))
    {
      // メインゲーム開始
      Application.LoadLevel("Main");
    }
  }
}
