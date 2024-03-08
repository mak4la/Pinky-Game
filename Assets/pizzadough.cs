using UnityEngine;

public class pizzadough : MonoBehaviour
{
    // Reference to the pepperoni prefab
    public GameObject pepperoniPrefab;

    // Method to handle dropping pepperonis onto the pizza dough
    public void DropPepperoni(Vector3 position)
    {
        // Instantiate a pepperoni object at the specified position
        GameObject pepperoni = Instantiate(pepperoniPrefab, position, Quaternion.identity);

        // Set the pizza dough object as the parent of the pepperoni
        pepperoni.transform.SetParent(transform);

        // Calculate the local position of the pepperoni relative to the pizza dough
        Vector3 localPosition = transform.InverseTransformPoint(position);

        // Set the local position of the pepperoni
        pepperoni.transform.localPosition = localPosition;
    }
}
