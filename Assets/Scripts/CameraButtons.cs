using UnityEngine;

public class CameraButtons : MonoBehaviour 
{
	public void SwitchCamera(int _targetCamera)
    {
        CameraManager.Instance.SetActiveCamera(_targetCamera);
    }
}
