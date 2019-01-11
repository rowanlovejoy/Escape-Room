using UnityEngine;

public class CameraButtons : MonoBehaviour 
{
	public void NextCamera()
    {
        CameraManager.Instance.NextCamera();
    }

    public void PreviousCamera()
    {
        CameraManager.Instance.PreviousCamera();
    }
}
