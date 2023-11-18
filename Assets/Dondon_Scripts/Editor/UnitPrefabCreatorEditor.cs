using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using UnityEngine.AI;
using Unity.VisualScripting;
using System.ComponentModel;

/// <summary>
/// Excelファイルから生成されたAntData内のAntStatsの値に応じてPrefabを生成するエディタ拡張
/// </summary>
[CustomEditor(typeof(UnitPrefabCreator))]
public class UnitPrefabCreatorEditor : Editor
{
    private const string PREFABPATH = "Assets/Prefabs/Units/";
    private const string IMAGEPATH = "Assets/Resources/Data/Images";

    private UnitPrefabCreator _target;

    private void OnEnable()
    {
        _target = (UnitPrefabCreator)target;
    }

    /// <summary>
    /// ボタン表示
    /// </summary>
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("プレハブの作成"))
        {
            // プロパティの更新
            serializedObject.Update();
            _target.MasterData.PrefabList.Clear();

            Create();

            // 変更を保存
            serializedObject.ApplyModifiedProperties();
        }
    }

    /// <summary>
    /// 実際の動作
    /// プレハブを作成し、AntDataのScriptableObjectにデータを流し込んでいる
    /// </summary>
    private void Create()
    {
        foreach (AntStats stats in _target.MasterData.StatsList)
        {
            switch (stats.Type)
            {
                case AntStats.UnitType.Carry:
                    //typeof(クラス名)でコンポーネントを追加できる
                    string unit_name = "CarryMove, Assembly-CSharp";
                    System.Type unit_move = System.Type.GetType(unit_name);
                    GameObject carryGameObject = EditorUtility.CreateGameObjectWithHideFlags(stats.Name, HideFlags.HideInHierarchy, typeof(SpriteRenderer), typeof(CircleCollider2D), typeof(CarryAnt), typeof(NavMeshAgent), unit_move);
                    AddImage(carryGameObject, stats);
                    CreatePrefab(carryGameObject, stats);
                    DestroyImmediate(carryGameObject);
                    break;

                case AntStats.UnitType.CC:
                    GameObject ccGameObject = EditorUtility.CreateGameObjectWithHideFlags(stats.Name, HideFlags.HideInHierarchy, typeof(SpriteRenderer), typeof(CCAnt), typeof(Move), typeof(NavMeshAgent));
                    AddImage(ccGameObject, stats);
                    CreatePrefab(ccGameObject, stats);
                    DestroyImmediate(ccGameObject);
                    break;
            }
        }
    }

    private void AddImage(GameObject gameObject, AntStats stats)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(IMAGEPATH + "/" + stats.ImageName);
    }

    private void CreatePrefab(GameObject gameObject, AntStats stats)
    {
        var prefab = PrefabUtility.SaveAsPrefabAsset(gameObject, PREFABPATH + gameObject.name + ".prefab");
        _target.MasterData.PrefabList.Add(prefab);
        //Prefab作成と同時にAntの初期ステータスを設定している
        prefab.GetComponent<Ant>().CreateAnt(stats);
    }
}