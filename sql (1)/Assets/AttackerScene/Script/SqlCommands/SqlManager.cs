using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqlManager: MonoBehaviour{
    #region Singleton
    public static SqlManager manager;
    private void Awake()
    {
        if(manager!= null)
        {
            Debug.Log("More than one instance of the SqlManager is present");
        }
        manager = this;
    }
    #endregion
    public HashText[] responseList;
    public HashText[] codeList;

    public string FindResponse(int index)
    {
        foreach(HashText h in responseList)
        {
            if(h.hash == index)
            {
                return h.content;
            }
        }
        return null;
    }

    public string FindCode(int index)
    {
        foreach (HashText h in codeList)
        {
            if (h.hash == index)
            {
                return h.content;
            }
        }
        return null;
    }



}
