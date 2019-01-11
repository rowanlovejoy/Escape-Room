using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Manager : MonoBehaviour 
{
    protected const string NO_REFERENCES_MESSAGES = "No References";

    protected abstract void OnSceneLoad(Scene _scene, LoadSceneMode _mode);

    protected abstract void InitialiseManager();

    protected abstract void SetReferences();
}
