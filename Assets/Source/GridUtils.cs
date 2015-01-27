using System.Globalization;
using UnityEngine;
using System.Collections;

public class GridUtils
{
	public static Vector3 GridStartPos(Vector3 gridPos, int numVoxel, float voxelSize)
	{
		var half = (numVoxel * voxelSize) / 2f;
		return gridPos - new Vector3(half, half, half);
	}

	public static Vector3 GridEndPos(Vector3 gridPos, int numVoxel, float voxelSize)
	{
		var half = (numVoxel * voxelSize) / 2f;
		return gridPos + new Vector3(half, half, half);
	}

	public static bool InGrid(Vector3 pos, Vector3 gridPos, int numVoxels, float voxelSize)
	{
		var start = GridStartPos(gridPos, numVoxels, voxelSize);
		var end = GridEndPos(gridPos, numVoxels, voxelSize);

		bool startOK = pos.x > start.x && pos.y > start.y && pos.z > start.z;
		bool endOK = pos.x < end.x && pos.y < end.y && pos.z < end.z;

		return startOK && endOK;
	}

	public static int World2Voxel(Vector3 pos, Vector3 gridPos, int numVoxels, float voxelSize)
	{
		if (!InGrid(pos, gridPos, numVoxels, voxelSize)) return -1;

		var x = (int) (pos.x / voxelSize);
		var y = (int) (pos.y / voxelSize);
		var z = (int) (pos.z / voxelSize);

		return x + y * numVoxels*numVoxels + numVoxels * z;
	}

	public static Vector3 VoxelPosition(Vector3 gridPos, int numVoxels, float voxelSize, int voxelNo)
	{
		var start = GridStartPos(gridPos, numVoxels, voxelSize);

		int x = voxelNo % numVoxels;
		int y = voxelNo / (numVoxels * numVoxels);
		int z = (voxelNo%(numVoxels*numVoxels))/numVoxels;

		float xPos = x * voxelSize + voxelSize / 2f;
		float yPos = y * voxelSize + voxelSize / 2f;
		float zPos = z * voxelSize + voxelSize / 2f;

		return start + new Vector3(xPos, yPos, zPos);
	}

}
