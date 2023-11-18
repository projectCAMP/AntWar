using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity Excel Importerを使用
/// URL : https://github.com/mikito/unity-excel-importer
/// 使用方法の参考URL : https://qiita.com/No2DGameNoLife/items/0e5b26e87d6b3041cf37
/// </summary>

[ExcelAsset]
public class AntData : ScriptableObject
{
    public List<AntStats> StatsList; // Replace 'EntityType' to an actual type that is serializable.
    public List<GameObject> PrefabList;

    /// <summary>
    /// ステータス検索用
    /// 素晴らしいchatgptが教えてくれました
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public AntStats GetDataByName(string name)
    {
        foreach (var dataObject in StatsList)
        {
            if (dataObject.Name == name)
            {
                return dataObject;
            }
        }
        return null; // 名前が一致するデータが見つからない場合はnullを返す
    }
}