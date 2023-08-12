using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Codice.CM.Client.Differences.Graphic;
using UnityEditor.U2D.PSD;
using System;

//参考：https://ekulabo.com/csv-to-scriptable-object

[CustomEditor(typeof(CSVImporter))]
public class CSVImpoterEditor : Editor
{
  public override void OnInspectorGUI()
  {
    var csvImpoter = target as CSVImporter;
    DrawDefaultInspector();

    if (GUILayout.Button("アリデータの作成"))
    {
      // Debug.Log("アリデータの作成ボタンが押された");
      SetCsvDataToScriptableObject(csvImpoter);
    }
  }

  void SetCsvDataToScriptableObject(CSVImporter csvImporter)
  {
    // ボタンを押されたらパース実行
    if (csvImporter.CSV == null)
    {
      Debug.LogWarning(csvImporter.name + " : 読み込むCSVファイルがセットされていません。");
      return;
    }

    // csvファイルをstring形式に変換
    string csvText = csvImporter.CSV.text;

    // 改行ごとにパース
    string[] afterParse = csvText.Split('\n');

    // ヘッダー行を除いてインポート
    for (int i = 1; i < afterParse.Length; i++)
    {
      string[] parseByComma = afterParse[i].Split(',');

      int column = 0;

      // 先頭の列が空であればその行は読み込まない
      if (parseByComma[column] == "")
      {
        continue;
      }

      // 行数をIDとしてファイルを作成
      string fileName = "antData_" + i.ToString("D4") + ".asset";
      string path = "Assets/Dondon_ScriptableObject/" + fileName;

      // AntStatsのインスタンスをメモリ上に作成
      var antData = CreateInstance<AntStats>();

      // 名前
      antData.Name = parseByComma[column];

      // タイプ
      column += 1;
      var typeName = Enum.Parse<UnitType>(parseByComma[column]);
      antData.Type = typeName;

      // コスト
      column += 1;
      antData.Cost = int.Parse(parseByComma[column]);

      // 体力
      column += 1;
      antData.Health = int.Parse(parseByComma[column]);

      // スピード
      column += 1;
      antData.Speed = int.Parse(parseByComma[column]);

      // パワー
      column += 1;
      antData.Power = int.Parse(parseByComma[column]);

      // インスタンス化したものをアセットとして保存
      var asset = (AntStats)AssetDatabase.LoadAssetAtPath(path, typeof(AntStats));
      if (asset == null)
      {
        // 指定のパスにファイルが存在しない場合は新規作成
        AssetDatabase.CreateAsset(antData, path);
      }
      else
      {
        // 指定のパスに既に同名のファイルが存在する場合は更新
        EditorUtility.CopySerialized(antData, asset);
        AssetDatabase.SaveAssets();
      }
      AssetDatabase.Refresh();
    }
    Debug.Log(csvImporter.name + " : アリデータの作成が完了しました。");
  }
}
