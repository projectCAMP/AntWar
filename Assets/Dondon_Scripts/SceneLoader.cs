using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 参考URL
/// http://negi-lab.blog.jp/SceneNameEnumCreator
/// </summary>
public class SceneLoader : Singleton<SceneLoader>
{
    public void SceneMove(SceneNameEnum sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    public void SceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}