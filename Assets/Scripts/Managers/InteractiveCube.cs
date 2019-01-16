using UnityEngine;

public class InteractiveCube : InteractiveObject 
{
    protected override void TriggerObjectFunction()
    {
        Debug.Log("You clicked me", gameObject);
    }

}
