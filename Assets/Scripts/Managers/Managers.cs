using System.Collections;
using System.Collections.Generic;
/*using UnityEditor.EditorTools;
using UnityEditor.SceneManagement;*/
using UnityEngine;
using UnityEngine.Windows;
using static Define;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    #region Contents
    //GameManagerEx _game = new GameManagerEx();

    //public static GameManagerEx Game { get { return Instance._game; } }
    #endregion

    #region Core
    //DataManager _data = new DataManager();
    InputManager _input = new InputManager();
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    //SceneManagerEx _scene = new SceneManagerEx();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();
    PatrolManager _patrol = new PatrolManager();
    PassPositionManager _passPosition = new PassPositionManager();

    //public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    //public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static PatrolManager Patrol { get { return Instance._patrol; } }
    public static PassPositionManager PassPosition { get { return Instance._passPosition; } }
    #endregion

    void Start()
    {
        Init();
    }

    void Update()
    {
        //_input.OnUpdate();
    }

    // 초기화 함수
    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            //s_instance._data.Init();
            //s_instance._pool.Init();
            s_instance._sound.Init();
            s_instance._patrol.Init();
            s_instance._passPosition.Init();
        }
    }

    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
        //Scene.Clear();
        UI.Clear();
        //Pool.Clear();
    }
}
