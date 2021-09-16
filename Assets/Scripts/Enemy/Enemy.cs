using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    //CONFIG PARAMS

    //CACHED INTERNAL REFERENCES
    internal EnemyMovement enemyMovement;

    //CACHED EXTERNAL REFERENCES

    private void OnEnable()
    {
        GetCachedReferences();
        StartCustomStarts();
    }

    private void GetCachedReferences()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void StartCustomStarts()
    {
        enemyMovement.CustomStart();
    }
}