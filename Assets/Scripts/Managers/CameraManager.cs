using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : Manager 
{
    private static CameraManager m_instance = null;
    [SerializeField]
    private Camera[] m_cameras = null;
    private Camera m_activeCamera = null;
    [SerializeField]
    private int m_startingCamera = 0;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    private void Awake()
    {
        InitialiseManager();
        SetReferences();
    }

    private void Start()
    {
        SetInitialCamera();
    }

    private void SetInitialCamera()
    {
        m_activeCamera = m_cameras[m_startingCamera];
    }

    protected override void InitialiseManager()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else if (m_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetActiveCamera(int _targetCamera)
    {
        m_activeCamera = m_cameras[_targetCamera];

        for (int i = 0; i < m_cameras.Length; i++)
        {
            if (m_cameras[i] != m_activeCamera)
            {
                m_activeCamera.enabled = false;
            }
        }

        m_activeCamera.enabled = true;
    }

    protected override void OnSceneLoad(Scene _scene, LoadSceneMode _mode)
    {
        SetReferences();
    }

    protected override void SetReferences()
    {
        Debug.Log(NO_REFERENCES_MESSAGES, gameObject);
    }

    public static CameraManager Instance
    {
        get
        {
            return m_instance;
        }
    }
}
