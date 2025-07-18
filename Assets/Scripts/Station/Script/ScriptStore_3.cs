using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptStore_3 : ScriptStore
{
    protected override void Awake()
    {
        base.Awake();
        stDictionary.Add("scene3_0", sentenceList_0);
        stDictionary.Add("scene3_1", sentenceList_1);
        stDictionary.Add("scene3_recall", sentenceList_2);
        stDictionary.Add("scene3_fail", sentenceList_3);
    }

    [SerializeField] List<string> sentenceList_0 = new List<string>();
    [SerializeField] List<string> sentenceList_1 = new List<string>();
    [SerializeField] List<string> sentenceList_2 = new List<string>();
    [SerializeField] List<string> sentenceList_3 = new List<string>();
}
