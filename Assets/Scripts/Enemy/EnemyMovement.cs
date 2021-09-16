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
            Vector2 startPosition = transform.position;
            Vector2 endPosition = waypoint.transform.position;
            float travelPercent = 0;

            Vector2 direction;
            if (startPosition.y == endPosition.y)
            {
                direction = startPosition - endPosition;
            }
            else
            {
                direction = endPosition - startPosition;
            }


            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            while(travelPercent < 1)
            {
                travelPercent += Time.deltaTime * movementSpeed;
                transform.position = Vector2.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
