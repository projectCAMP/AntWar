using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : Singleton<T> //Singletonクラスを継承したクラスのみを対象に
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null) //_instanceがnullならば、
            {
                _instance = FindObjectOfType(typeof(T)) as T; //クラスを探す
                if (_instance == null)
                {
                    SetupInstance();
                }
            }
            return _instance;
        }
    }

    public virtual void Awake()
    {
        RemoveDuplicates();
    }

    private static void SetupInstance()
    {
        _instance = (T)FindObjectOfType(typeof(T));
        if (_instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(T).Name;
            _instance = gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }
    }

    private void RemoveDuplicates()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}