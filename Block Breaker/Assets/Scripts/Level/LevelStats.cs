using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    [SerializeField] private int _levelScore;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.CompareTag("Block"))
            {
                _levelScore += transform.GetChild(i).GetComponent<BlockManager>().GetBlockValue();
            }
        }
    }

    public int GetLevelScore() 
    {
        return _levelScore;
    }
}
