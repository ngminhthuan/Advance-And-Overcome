using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerGameData : MonoBehaviour
{
    private static PlayerGameData _instance;

    public static PlayerGameData Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public int totalDiamond;
    public float musicVolumeMenu;
    public float musicVolumeLevel;
    public float sfxVolume;
    public int currentCharacter;
    public int mapcurrentUnlock;
    public List<int> listCharacterID = new List<int>();
    public List<int> ListMap = new List<int>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        LoadGameData();
    }

    private void OnApplicationQuit()
    {
        //SaveGameData();
    }

    public PlayerGameData LoadGameData()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerGameData data = (PlayerGameData)bf.Deserialize(file);
            file.Close();

            totalDiamond = data.totalDiamond;
            musicVolumeMenu = data.musicVolumeMenu;
            musicVolumeLevel = data.musicVolumeLevel;
            sfxVolume = data.sfxVolume;
            currentCharacter = data.currentCharacter;
            mapcurrentUnlock = data.mapcurrentUnlock;
            listCharacterID = data.listCharacterID;
            ListMap = data.ListMap;
        }
        else
        {
            InitializeDefaultData();
        }
        return this;
    }

    public PlayerGameData() {
    }
    public void SaveSetting(float musicMenu, float musicLevel, float sfx)
    {
        musicVolumeMenu = musicMenu;
        musicVolumeLevel = musicLevel;
        sfxVolume = sfx;
        SaveGameData();
    }

    public void SaveGameData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
        PlayerGameData data = new PlayerGameData();

        data.totalDiamond = totalDiamond;
        data.musicVolumeMenu = musicVolumeMenu;
        data.musicVolumeLevel = musicVolumeLevel;
        data.sfxVolume = sfxVolume;
        data.currentCharacter = currentCharacter;
        data.mapcurrentUnlock = mapcurrentUnlock;
        data.listCharacterID = listCharacterID;
        data.ListMap = ListMap;

        bf.Serialize(file, data);
        file.Close();
    }

    private void InitializeDefaultData()
    {
        totalDiamond = DefaultData.Diamond;
        musicVolumeMenu = DefaultData.musicVolumeMenu;
        musicVolumeLevel = DefaultData.musicVolumeLevel;
        sfxVolume = DefaultData.sfxVolume;
        currentCharacter = DefaultData.characterid;
        mapcurrentUnlock = DefaultData.Map;
        listCharacterID = new List<int>();
        ListMap = new List<int>();
    }

    // Your other methods...
    public void AddNewMap(int mapID)
    {
        if (!ListMap.Contains(mapID))
        {
            ListMap.Add(mapID);
        }
        SaveGameData();
    }

    public void AddNewCharacter(int characterID)
    {
        if (!listCharacterID.Contains(characterID))
        {
            listCharacterID.Add(characterID);
        }
        SaveGameData();
    }

    public void AddDimond(int valueAdd)
    {
        this.totalDiamond += valueAdd;
        SaveGameData();
    }

    public void RemoveDimond(int valueRemove)
    {
        this.totalDiamond -= valueRemove;
        SaveGameData();
    }
    public void ResetAllData()
    {
        SaveManager.DeleteSaveData(); // Xóa dữ liệu 
    }
    public void UseNewCharacter(int characterId)
    {
        currentCharacter = characterId;
        SaveGameData();
    }
}

public class DefaultData
{
    public const int characterid = 0;
    public const int Diamond = 0;
    public const float musicVolumeMenu = 1f;
    public const float musicVolumeLevel = 1f;
    public const float sfxVolume = 1f;
    public const int Map = 1;
}
