using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPostion, rightPosition;

    private GameObject spawnMonster;
    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnMonster = Instantiate(monsterReference[randomIndex]);//copy an object

            //left side
            if (randomSide ==0)
            {
                spawnMonster.transform.position = leftPostion.transform.position;
                spawnMonster.GetComponent<Monster>().speed = Random.Range(5, 10);
            }
            else
            {
                spawnMonster.transform.position = rightPosition.transform.position;
                spawnMonster.GetComponent<Monster>().speed = -Random.Range(5, 10);
                spawnMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
