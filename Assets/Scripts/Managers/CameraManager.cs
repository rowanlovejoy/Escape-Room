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
        if (m_cameras.Length == 0)
        {
            m_activeCamera = GameObject.Find("Camera1").GetComponent<Camera>();
        }
        else
        {
            m_activeCamera = m_cameras[m_startingCamera];
        }

        m_activeCamera.enabled = true;

        foreach (Camera element in m_cameras)
        {
            if (element != m_activeCamera)
            {
                element.enabled = false;
            }
        }
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

    private void SetActiveCamera(bool _next)
    {
        for (int i = 0; i < m_cameras.Length; i++)
        {
            if (m_cameras[i] == m_activeCamera)
            {
                if (_next)
                {
                    if ((i + 1) < m_cameras.Length)
                    {
                        m_activeCamera = m_cameras[i + 1];

                        Debug.Log("Switched to Camera: " + m_activeCamera.name);
                    }
                    else
                    {
                        Debug.Log("No next camera" + m_activeCamera.name);
                    }
                }
                else
                {
                    if ((i - 1) >= 0)
                    {
                        m_activeCamera = m_cameras[i - 1];
                        Debug.Log("Switched to Camera: " + m_activeCamera.name);
                    }
                    else
                    {
                        Debug.Log("No previous camera" + m_activeCamera.name);
                    }
                }
            }
        }

        foreach (Camera element in m_cameras)
        {
            if (element != m_activeCamera)
            {
                element.enabled = false;
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
	
	public void NextCamera()
    {
        SetActiveCamera(true);
    }

    public void PreviousCamera()
    {
        SetActiveCamera(false);
    }

    public static CameraManager Instance
    {
        get
        {
            return m_instance;
        }
    }
}
