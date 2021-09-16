using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemyMovement : MonoBehaviour
{
    //STATS
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float movementSpeed = 1f;

    //CACHED INTERNAL REFERENCES
    Enemy enemy;

    internal void CustomStart()
    {
        enemy = GetComponent<Enemy>();

        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            Debug.Log($"{name} is now in {waypoint.name}");
            yield return new WaitForSeconds(movementSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
