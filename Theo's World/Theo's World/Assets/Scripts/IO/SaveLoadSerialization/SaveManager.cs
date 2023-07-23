using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
  public string saveFilePrefix = "save";
  public string saveFileExtension = ".json";
  public int saveSlotSelected = 0;
  public GameData gameData;

  private string saveDirectoryPath;

  void Start()
  {
    saveDirectoryPath = Application.persistentDataPath;
    LoadGame(saveSlotSelected);
  }

  public void SaveGame(int saveSlot)
  {
    string saveFileName = saveFilePrefix + saveSlot + saveFileExtension;
    string saveFilePath = Path.Combine(saveDirectoryPath, saveFileName);

    string jsonData = JsonUtility.ToJson(gameData, true);
    File.WriteAllText(saveFilePath, jsonData);
  }

  public void LoadGame(int saveSlot)
  {
    string saveFileName = saveFilePrefix + saveSlot + saveFileExtension;
    string saveFilePath = Path.Combine(saveDirectoryPath, saveFileName);

    if (File.Exists(saveFilePath))
    {
      string jsonData = File.ReadAllText(saveFilePath);
      gameData = JsonUtility.FromJson<GameData>(jsonData);
    }
    else
    {
      gameData = new GameData();
    }
  }
}
