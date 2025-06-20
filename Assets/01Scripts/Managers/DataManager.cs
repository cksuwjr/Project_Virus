using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class DataManager : Singleton<DataManager>, IManager
{
    public readonly string ADDRESS = "https://docs.google.com/spreadsheets/d/1XnYIk7xsyaXOV8ZlURqPKc2CVfqWNUtT42XZ7hGddUg";
    public readonly string RANGE = "A2:D";
    public readonly long SHEET_ID = 0;

    [SerializeField] private List<StageData> stageData;

    private string dataPath;


    public void Init()
    {
        // Computer
        StartCoroutine("LoadSheetData");
    }

    private IEnumerator LoadSheetData()
    {
        UnityWebRequest www = UnityWebRequest.Get(ReadSpreadSheet(ADDRESS, RANGE, SHEET_ID));
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            stageData = ParsingSheet.GetDatas<StageData>(www.downloadHandler.text);
            SaveStageData();
        }
        else
            LoadStageData();
    }

    public void SaveStageData()
    {
        dataPath = Application.persistentDataPath + "/Save";
        Debug.Log(dataPath);
        string data = JsonList.ToJson(stageData);
        File.WriteAllText(dataPath, data);
    }

    public void LoadStageData()
    {
        dataPath = Application.persistentDataPath + "/Save";
        if (File.Exists(dataPath))
        {
            string data = File.ReadAllText(dataPath);
            stageData = JsonList.FromJson<StageData>(data);
        }
    }

    //public bool LoadData()
    //{
    //    dataPath = Application.persistentDataPath + "/Save";
    //    if (File.Exists(dataPath))
    //    {
    //        string data = File.ReadAllText(dataPath);
    //        stageData = JsonUtility.FromJson<List<StageData>>(data);
    //        return true;
    //    }
    //    return false;
    //}

    //public void SaveData()
    //{
    //    dataPath = Application.persistentDataPath + "/Save";

    //    string data = JsonUtility.ToJson(stageData);
    //    File.WriteAllText(dataPath, data);
    //}

    public void DeleteData()
    {
        File.Delete(dataPath);
    }

    public string ReadSpreadSheet(string address, string range, long sheetID)
    {
        return $"{address}/export?format=tsv&range={range}&gid={sheetID}";
    }

    public StageData GetStageData(int id)
    {
        return stageData[id];
    }

    public int GetStageCount()
    {
        return stageData.Count;
    }
}
