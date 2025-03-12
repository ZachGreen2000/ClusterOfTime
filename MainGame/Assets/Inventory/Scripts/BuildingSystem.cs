/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{

    [SerializeField] private TileBase highlightTile;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private Tilemap tempTilemap;

    [SerializeField] private GameObject lootPrefab;

    private Vector3Int playerPos;
    private Vector3Int highlightTilePos;
    private bool highlighted;

    void Update()
    {
        Item item = InventoryManager.instance.GetSelectedItem(false);

        playerPos = mainTilemap.WorldToCell(transform.position);

        if(item != null)
        {
            HighlightTile(item);
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(highlighted)
            {
                if(item.type == ItemType.BuildingBlock)
                {
                    Build(highlightTilePos, item);
                }
                else if(item.type == ItemType.Tool)
                {
                    Destroy(highlightTilePos);
                }
            }
        }
    }
}
*/
