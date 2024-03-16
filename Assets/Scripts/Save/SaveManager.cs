using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void Save()
    {
        PlayerGameData.Instance.SaveGameData();
    }

    public static PlayerGameData Load()
    {
        return PlayerGameData.Instance.LoadGameData();
    }


    public static string GetPath()
    {
        return Application.persistentDataPath + ".data.qnd";
    }

    public static void DeleteSaveData()
    {
        string path = GetPath();
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save data deleted.");
        }
        else
        {
            Debug.Log("No save data found.");
        }
    }
}
