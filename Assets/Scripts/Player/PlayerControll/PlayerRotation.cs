using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Camera mainCamera;

    private void Update()
    {
        Vector2 positionOnScreen = mainCamera.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)mainCamera.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetween(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle - 90, 0f));
    }

    

    float AngleBetween(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}