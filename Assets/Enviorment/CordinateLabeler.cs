using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    // Waypoint waypoint;
    GridManager gridManager;
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        // waypoint = GetComponentInParent<Waypoint>();
        DisplayCordinates();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabels();
    }
    void ToggleLabels()
    {
        if(Input.GetKey(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
    void SetLabelColor()
    {
        if(gridManager == null) {return;}

        Node node = gridManager.GetNode(coordinates);

        if(node == null) {return;}
        if(!node.isWalkable)
        {
            label.color = blockedColor;
        }else if(node.isPath)
        {
            label.color = pathColor;
        }else if(node.isExplored)
        {
            label.color = exploredColor;
        }else{
            label.color = defaultColor;
        }

    }
    void DisplayCordinates()
    {
        if(gridManager == null){return;}
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
        label.text = coordinates.x +","+ coordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
