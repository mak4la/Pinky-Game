using System.Collections;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed = 5;

    public void Launch(Vector3 targetPos)
    {
        GameObject newProjectile = ObjectPool.Instance.GetObjectFromPool();
        if (newProjectile != null)
        {
            newProjectile.transform.position = transform.position;
            newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward, targetPos - transform.position);
            newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up * speed;

            // Activate a coroutine to deactivate the projectile after a certain time
            StartCoroutine(DeactivateAfterTime(newProjectile, 5));
        }
    }

    private IEnumerator DeactivateAfterTime(GameObject projectile, float time)
    {
        yield return new WaitForSeconds(time);
        // Check if the projectile object is not null before deactivating it
        if (projectile != null)
        {
            projectile.SetActive(false);
        }
    }
}

