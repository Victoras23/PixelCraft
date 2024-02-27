using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainModifier : MonoBehaviour
{
    public LayerMask groundLayer;

    public Inventory inv;

    float maxDist = 4;

    void Start()
    {
        
    }

    void Update()
    {
        bool leftClick = Input.GetMouseButtonDown(0);
        bool rightClick = Input.GetMouseButtonDown(1);
        if(leftClick || rightClick)
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(transform.position, transform.forward, out hitInfo, maxDist, groundLayer))
            {
                Vector3 pointInTargetBlock;

                if(leftClick)
                    pointInTargetBlock = hitInfo.point + transform.forward * .01f;
                else
                    pointInTargetBlock = hitInfo.point - transform.forward * .01f;

                int chunkPosX = Mathf.FloorToInt(pointInTargetBlock.x / 16f) * 16;
                int chunkPosZ = Mathf.FloorToInt(pointInTargetBlock.z / 16f) * 16;

                ChunkPos cp = new ChunkPos(chunkPosX, chunkPosZ);

                TerrainChunk tc = TerrainGenerator.chunks[cp];

                int bix = Mathf.FloorToInt(pointInTargetBlock.x) - chunkPosX+1;
                int biy = Mathf.FloorToInt(pointInTargetBlock.y);
                int biz = Mathf.FloorToInt(pointInTargetBlock.z) - chunkPosZ+1;

                if(leftClick)
                {
                    inv.AddToInventory(tc.blocks[bix, biy, biz]);
                    tc.blocks[bix, biy, biz] = BlockType.Air;
                    tc.BuildMesh();
                }
                else if(rightClick)
                {
                    if(inv.CanPlaceCur())
                    {
                        tc.blocks[bix, biy, biz] = inv.GetCurBlock();

                        tc.BuildMesh();

                        inv.ReduceCur();
                    }
                    
                }
            }
        }
    }
}
