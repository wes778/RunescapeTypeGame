using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    #region Singleton
    public static QuestManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one instance of Questmanager");
            return;
        }
        instance = this;
    }
    #endregion
    public List<string> inactiveQuests = new List<string>();
    public List<string> activeQuests = new List<string>();
    public List<string> finishedQuests = new List<string>();

    public bool IsQuestFinished(string name)
    {
        for(int i = 0; i < finishedQuests.Count; i++)
        {
            if (finishedQuests[i].Equals(name))
            {
                return true;
            }
        }
        return false;
    }

    public bool IsQuestActive(string name)
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].Equals(name))
            {
                return true;
            }
        }
        return false;
    }
    public bool IsQuestInactive(string name)
    {
        for (int i = 0; i < inactiveQuests.Count; i++)
        {
            if (inactiveQuests[i].Equals(name))
            {
                return true;
            }
        }
        return false;
    }

    public void ActiveToFinsiehd(string finishedQuestName)
    {
        activeQuests.Remove(finishedQuestName);
        finishedQuests.Add(finishedQuestName);
    }

    public void InactiveToActive(string nameOfQuest)
    {
        inactiveQuests.Remove(nameOfQuest);
        activeQuests.Add(nameOfQuest);
    }
}
