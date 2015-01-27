using UnityEngine;
using System.Collections;

public class UniformGrid
{
	public static GameObject CreateVoxel(Vector3 pos, float scale = 1f)
	{
		var voxel = GameObject.CreatePrimitive(PrimitiveType.Cube);
		voxel.collider.enabled = false;
		voxel.renderer.enabled = false;
		voxel.transform.position = pos;
		voxel.transform.localScale = new Vector3(scale, scale, scale);
		voxel.name = "voxel";
		return voxel;
	}

	public static GameObject CreateUniformGrid(Vector3 startPos, int numVoxels, float sizeOfVoxel)
	{
		var voxelStartXYZ = sizeOfVoxel / 2f;
		var gridXYZ = (numVoxels / 2f) * sizeOfVoxel;
		var voxelStartPos = startPos + new Vector3(voxelStartXYZ, voxelStartXYZ, voxelStartXYZ);
		var gridPos = startPos + new Vector3(gridXYZ, gridXYZ, gridXYZ);
		var parentGO = new GameObject();
		parentGO.transform.position = startPos + gridPos;
		parentGO.name = "UniformGrid";

		for (int i = 0; i < numVoxels; i++)
		{
			for (int j = 0; j < numVoxels; j++)
			{
				for (int k = 0; k < numVoxels; k++)
				{
					float xPos = k * sizeOfVoxel;
					float yPos = i * sizeOfVoxel;
					float zPos = j * sizeOfVoxel;
					var newPos = new Vector3(xPos, yPos, zPos);
					var vox = CreateVoxel(voxelStartPos + newPos, sizeOfVoxel);
					vox.transform.parent = parentGO.transform;
				}
			}
		}
		return parentGO;
	}
}
