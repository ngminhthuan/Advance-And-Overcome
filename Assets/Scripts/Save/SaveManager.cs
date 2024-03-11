using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void Save(PlayerGameData data)
    {
        string path = Application.persistentDataPath + ".data.qnd";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static PlayerGameData Load()
    {
        string path = GetPath();

        if (!File.Exists(path))
        {
            Debug.Log("No save data found. Creating new data.");
            PlayerGameData.Instance = new PlayerGameData();
            Save(PlayerGameData.Instance);
            return PlayerGameData.Instance;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Open);
        PlayerGameData data = formatter.Deserialize(fs) as PlayerGameData;
        fs.Close();

        return data;
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
