using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour 
{
    private void OnMouseOver()
    {
        Debug.Log("Mouse is over object", gameObject);
        if (InputManager.Instance.Confirm)
        {
            Debug.Log("Object has been clicked on", gameObject);
            TriggerObjectFunction();
        }
    }

    protected abstract void TriggerObjectFunction();

}
