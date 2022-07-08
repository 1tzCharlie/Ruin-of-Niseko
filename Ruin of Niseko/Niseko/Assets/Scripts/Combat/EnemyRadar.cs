using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    private GameObject[] enemies;
    public Transform closestEnemy;
    public bool enemyContact;

    private void Start()
    {
        closestEnemy = GetClosestEnemy();
        enemyContact = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger == true)
        {
            if (collision.CompareTag("Hittable"))
            {
                closestEnemy = GetClosestEnemy();
                enemyContact = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger == true)
        {
            if (collision.CompareTag("Hittable"))
            {
                enemyContact = false;
            }
        }
    }

    public Transform GetClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Hittable");

        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in enemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }

        return trans;
    }
}
