using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }        // property = getter method (property is cleaner than a method because it ensures us that nothing is changing along the way (something else in the method))

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start() {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }


    // public bool GetIsPlaceable()
    // {
    //     return isPlaceable;
    // }

    // void OnMouseOver() {
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //         Debug.Log(transform.name);
    //     }
    // }

    void OnMouseDown() 
    {
        if(gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            // Debug.Log(transform.name);

            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
            if(isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }

        }

    }
}
