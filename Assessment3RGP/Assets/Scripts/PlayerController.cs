using System;

using UnityEngine;
using System.Collections;

using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
	public int health = 3;
	public bool hasTurn = true;
	public bool crossUsed = false; // Track if the cross has been used
	public GameObject crossPrefab;
	public GameObject syringePrefab;
	public GameObject gunPrefab;
	private GameObject cross;
	private GameObject syringe;
	private GameObject gun;
	
	public AudioSource gunSource;
	public AudioSource syringeSource;
	public AudioSource crossSource;
	public AudioClip gunSound;
	public AudioClip syringeSound;
	public AudioClip crossSound;

	private void Start()
	{
		gunSource = GetComponent<AudioSource>();
		syringeSource = GetComponent<AudioSource>();
		crossSource = GetComponent<AudioSource>();
	}

	public void UseCross(PlayerController opponent)
	{
		cross = Instantiate(crossPrefab, transform.position, Quaternion.identity);
		opponent.crossUsed = true;
		crossSource.PlayOneShot(crossSound);
		StartCoroutine(DespawnObject(cross));
	}

	public void UseSyringe()
	{
		syringe = Instantiate(syringePrefab, transform.position, Quaternion.identity);
		health++;
		syringeSource.PlayOneShot(syringeSound);
		StartCoroutine(DespawnObject(syringe));
	}

	public void Shoot(PlayerController opponent)
	{
		gun = Instantiate(gunPrefab, transform.position, Quaternion.identity);
		if (Random.value > 0.5f)
		{
			opponent.health -= 3;
		}
		gunSource.PlayOneShot(gunSound);
		StartCoroutine(DespawnObject(gun));
	}

	private IEnumerator DespawnObject(GameObject obj)
	{
		yield return new WaitForSeconds(1.0f); // Wait for 1 second before despawning
		Destroy(obj);
	}

	public void GetRandomItem()
	{
		int item = Random.Range(0, 2);
		if (item == 0)
		{
			// Get cross
			crossPrefab.SetActive(true);
		}
		else
		{
			// Get syringe
			syringePrefab.SetActive(true);
		}
	}
}