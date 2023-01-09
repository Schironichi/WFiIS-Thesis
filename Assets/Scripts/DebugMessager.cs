using UnityEngine;

public class DebugMessager : MonoBehaviour
{
    public void Notify()
    {
        Debug.Log("ACTIVATED");
    }

    public void Shout(string msg)
    {
        Debug.Log(msg);
    }
}
