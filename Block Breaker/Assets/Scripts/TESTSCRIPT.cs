using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TESTSCRIPT : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    public Coroutine destroyBlocks;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            blocks.Clear();
            blocks = GameObject.FindGameObjectsWithTag("Block").ToList();

            destroyBlocks = StartCoroutine(DestroyBlocks());
        }
    }

    IEnumerator DestroyBlocks()
    {
        foreach (GameObject block in blocks)
        {
            LevelManager.Instance.AddScore(block.GetComponent<BlockManager>().GetBlockValue());
            Destroy(block);
            yield return new WaitForSeconds(0.1f);
        }

        if (destroyBlocks != null) 
        {
            StopCoroutine(destroyBlocks);
        }
    }
}
