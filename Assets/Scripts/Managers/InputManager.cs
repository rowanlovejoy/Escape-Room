using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : Manager 
{
    private static InputManager m_instance = null;

    private bool m_quit = false;
    private bool m_confirm = false;

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

    protected override void InitialiseManager()
    {
        if (m_instance == null)
        {
            m_instance = this;
        } else if (m_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    protected override void OnSceneLoad(Scene _scene, LoadSceneMode _mode)
    {
        SetReferences();
    }

    protected override void SetReferences()
    {
        Debug.Log(NO_REFERENCES_MESSAGES, gameObject);
    }

    private void Update() 
	{
        SetInputs();
	}

    private void SetInputs()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            m_quit = true;
        }
        else
        {
            m_quit = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            m_confirm = true;
        }
        else
        {
            m_confirm = false;
        }
    }

    public bool Confirm
    {
        get
        {
            return m_confirm;
        }
    }

    public bool Quit
    {
        get
        {
            return m_quit;
        }
    }

    public static InputManager Instance
    {
        get
        {
            return m_instance;
        }
    }
}
