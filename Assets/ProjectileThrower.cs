using System.Collections;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    public void Launch(Vector3 targetPos)
    {
        GameObject newProjectile = ObjectPool.Instance.GetObjectFromPool();
        newProjectile.transform.position = transform.position;
        newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward, targetPos - transform.position);
        newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up * speed;

        // Activate a coroutine to deactivate the projectile after a certain time
        StartCoroutine(DeactivateAfterTime(newProjectile, 5));
    }

    private IEnumerator DeactivateAfterTime(GameObject projectile, float time)
    {
        yield return new WaitForSeconds(time);
        projectile.SetActive(false);
    }
}
