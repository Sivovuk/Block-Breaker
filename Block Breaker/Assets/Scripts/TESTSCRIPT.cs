using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TESTSCRIPT : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    public Coroutine destroyBlocks;
    public GameObject ball;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        ball.SetActive(false);
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) 
        //{
        //    blocks.Clear();
        //    blocks = GameObject.FindGameObjectsWithTag("Block").ToList();

        //    destroyBlocks = StartCoroutine(DestroyBlocks());
        //}

        if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Time.timeScale--;
        }
        if (Time.timeScale < 10 && Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Time.timeScale++;
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
