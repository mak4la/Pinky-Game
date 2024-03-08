using UnityEngine;

public class PepperoniSlice : MonoBehaviour
{
    // Reference to the pizza dough object
    public GameObject pizzaDough;

    private void OnMouseDrag()
    {
        // If the user is dragging the pepperoni slice, move it with the mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the slice stays on the same z-position
        transform.position = mousePosition;
    }

    private void OnMouseUp()
    {
        // If the user releases the pepperoni slice, check if it's over the pizza dough
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == pizzaDough)
        {
            // If the pepperoni slice is released over the pizza dough, attach it to the dough
            transform.SetParent(pizzaDough.transform);
            transform.localPosition = Vector3.zero; // Set local position to (0, 0, 0) on the dough
        }
        else
        {
            // If the pepperoni slice is released elsewhere, detach it from the dough
            transform.SetParent(null);
        }
    }
}

