using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameData : MonoBehaviour
{
    private static PlayerGameData _instance;

    // Public property to access the singleton instance
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
            _instance = SaveManager.Load();
        }
    }
    public PlayerGameData()
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


    public PlayerGameData(float musicMenu, float musicLevel, float sfx, List<int> characterList = null, List<int> MapList = null)
    {
        musicVolumeMenu = musicMenu;
        musicVolumeLevel = musicLevel;
        sfxVolume = sfx;
        if(characterList!= null)
        {
            listCharacterID = characterList;
        }

        if(MapList != null)
        {
            ListMap = MapList;
        }
    }

    public void AddNewMap(int mapID)
    {
        if(!ListMap.Contains(mapID))
        {
            ListMap.Add(mapID);
        }
        SaveManager.Save(this);
    }
    
    public void AddNewCharacter(int characterID)
    {
        if(!listCharacterID.Contains(characterID))
        {
            listCharacterID.Add(characterID);
        }
        SaveManager.Save(this);
    }

    public void AddDimond(int valueAdd)
    {
        this.totalDiamond += valueAdd;
        SaveManager.Save(this);
    }
    
    public void RemoveDimond(int valueRemove)
    {
        this.totalDiamond -= valueRemove;
        SaveManager.Save(this);
    }
    public void ResetAllData()
    {
        SaveManager.DeleteSaveData(); // Xóa dữ liệu 
    }

    public void UseNewCharacter(int characterId)
    {
        currentCharacter = characterId;
        SaveManager.Save(this);
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
