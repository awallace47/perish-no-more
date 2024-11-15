using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    float z;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void Start()
    {
        z = transform.position.z;

        SetCameraPosition();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (followObject == null)
        {
            followObject = GameObject.Find("Player");
        }
    }

    void LateUpdate()
    {
        if (followObject == null) return;

        SetCameraPosition();
    }

    void SetCameraPosition()
    {
        float x = followObject.transform.position.x;
        float y = followObject.transform.position.y;

        transform.position = new Vector3(x, y, z);
    }
}
