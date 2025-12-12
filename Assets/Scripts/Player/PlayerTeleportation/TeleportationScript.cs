using UnityEngine;

public class TeleportationScript : MonoBehaviour
{
    public float mapWidth = 40f;
    public float mapHeight = 40f;

    private CharacterController characterController;
    private GameObject mainCameraTransform;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        mainCameraTransform = Camera.main.gameObject;
    }

    void LateUpdate()
    {
        WarpPosition();
    }
    
    private void WarpPosition()
    {
        Vector3 pos = transform.position;

        if (pos.x > mapWidth)
        {
            pos.x = 0f;
        } 
        else if (pos.x < 0f)
        {
            pos.x = mapWidth;
        }

        if (pos.z > mapHeight)
        {
            pos.z = 0f;
        } 
        else if (pos.z < 0f) 
        {
            pos.z = mapHeight;
        }


        // Можно добавить бесшовность даже со следящей плавной камерой, если останется время
        characterController.enabled = false;
        transform.position = pos;
        mainCameraTransform.transform.position = new Vector3(pos.x, mainCameraTransform.transform.position.y, pos.z);
        characterController.enabled = true;
    }
}
