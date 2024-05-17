using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string SAVED_GAME = "savedGame";

    public static void SavedGame(SaveData data)
    {
        PlayerPrefs.SetString(SAVED_GAME, JsonUtility.ToJson(data));
    }

    public static SaveData LoadGame()
    {
        return JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(SAVED_GAME));
    }

    public static bool IsGameSaved()
    {
        return PlayerPrefs.HasKey(SAVED_GAME);
    }

    public static void ClearSavedGame()
    {
        PlayerPrefs.DeleteKey(SAVED_GAME);
    }

    internal static void SaveGame(SaveData data)
    {
        throw new NotImplementedException();
    }
}
