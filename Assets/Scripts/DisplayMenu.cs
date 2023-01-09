using UnityEngine;

public class DisplayMenu : MonoBehaviour
{
    public GameObject menuObject;
    public GameObject headsetAlias;
    public float spawnDistance = 0.8f;

    public void ToggleMenu()
    {
        Debug.Log("toggling");
        if (menuObject != null)
        {
            if (menuObject.activeSelf)
            {
                menuObject.SetActive(false);
            } else {
                menuObject.transform.SetPositionAndRotation(headsetAlias.transform.position + headsetAlias.transform.TransformDirection(0f, 0f, spawnDistance), headsetAlias.transform.rotation);
                menuObject.transform.Rotate(-90f, 0f, 0f, Space.Self);
                menuObject.SetActive(true);
            }
        }
    }
}
