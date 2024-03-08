using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseDrag : MonoBehaviour
{
    Vector3 mousePositionOffset;


    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

}
