﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Memento
{
    /// <summary>
    /// Save a serializable class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_serializableClass"></param>
    public static void SaveData<T>(T _serializableClass) where T : class
    {
        if (!Directory.Exists(Application.persistentDataPath + "/game_save"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }

        if (!Directory.Exists(string.Format("{0}/game_save/{1}", Application.persistentDataPath, _serializableClass.ToString())))
        {
            Directory.CreateDirectory(string.Format("{0}/game_save/{1}", Application.persistentDataPath, _serializableClass.ToString()));
        }

        FileStream fileStream = File.Create(string.Format("{0}/game_save/{1}/{2}.txt", Application.persistentDataPath, _serializableClass.ToString(), _serializableClass.ToString()));
        BinaryFormatter bf = new BinaryFormatter();
        string json = JsonUtility.ToJson(_serializableClass);
        Debug.Log(json.ToString());
        bf.Serialize(fileStream, json);
        fileStream.Close();
    }

    /// <summary>
    /// Load data
    /// </summary>
    /// <typeparam name="T">Serializable class to override</typeparam>
    /// <param name="_serializableClass">Serializable class to override</param>
    public static void LoadData<T>(T _serializableClass) where T : class
    {
        if (!Directory.Exists(string.Format("{0}/game_save/{1}", Application.persistentDataPath, _serializableClass.ToString())))
        {
            Directory.CreateDirectory(string.Format("{0}/game_save/{1}", Application.persistentDataPath, _serializableClass.ToString()));
        }

        if (File.Exists(string.Format("{0}/game_save/{1}/{2}.txt", Application.persistentDataPath, _serializableClass.ToString(), _serializableClass.ToString())))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Format("{0}/game_save/{1}/{2}.txt", Application.persistentDataPath, _serializableClass.ToString(), _serializableClass.ToString()), FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), _serializableClass);
            file.Close();
        }
    }

    /// <summary>
    /// Delete the .txt file from the class provided
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_serializableClass"></param>
    public static void ClearData<T>(T _serializableClass) where T :class
    {
        File.Delete(string.Format("{0}/game_save/{1}/{2}.txt", Application.persistentDataPath, _serializableClass.ToString(), _serializableClass.ToString()));
    }
}
