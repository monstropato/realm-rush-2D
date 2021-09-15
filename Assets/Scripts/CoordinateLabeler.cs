using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    //CONFIG PARAMS

    //CACHED CLASSES REFERENCES
    internal TextMeshPro textCoordinates;
    //CACHED EXTERNAL REFERENCES


    private void Awake()
    {
        textCoordinates = GetComponentInChildren<TextMeshPro>();
        LabelCoordinate();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            LabelCoordinate();
        }   
    }

    private void LabelCoordinate()
    {
        textCoordinates.text = $"{GetCoordinates()}";
        gameObject.name = $"Tile {GetCoordinates()}";
    }

    private Vector2Int GetCoordinates()
    {
        int xCoordinate = Mathf.RoundToInt(transform.position.x);
        int yCoordinate = Mathf.RoundToInt(transform.position.y);
        return new Vector2Int(xCoordinate, yCoordinate);
    }
}
