using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PipesPrefab;

    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

	private void OnEnable()
	{
		InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
	}

	private void OnDisable()
	{
		CancelInvoke(nameof(Spawn));
	}

	private void Spawn()
	{
		GameObject pipes = Instantiate(PipesPrefab, transform.position, Quaternion.identity);
		pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
	}

	public void UpdateDifficulty(float newSpawnRate, float newMinHeight, float newMaxHeight)
	{
		spawnRate = newSpawnRate;
		minHeight = newMinHeight;
		maxHeight = newMaxHeight;

		// 重置InvokeRepeating以应用新的spawnRate
		CancelInvoke(nameof(Spawn));
		InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
	}
}
