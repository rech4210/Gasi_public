using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class DataManager : Events<DataManager>, IGetDict<BuffData>,IGetDict<AttackData>, IGetDict<PlayerStatStruct>
{
    string path = null;
    int buffCounts = 100;

    #region 플레이어 정보
    PlayerStatStruct playerStatStruct;
    Transform playerTransform;

    public delegate void PlayerStatDelegate (PlayerStatStruct stat);
    public PlayerStatDelegate PlayerStatDele;

    public PlayerStatStruct _playerStat { get { return playerStatStruct; }set { }}
    public Transform _playerTransform { get { return playerTransform; } set { } }
    public void UpdatePlayerData(PlayerStatStruct statStruct, PlayerStat stat) 
    {
        playerStatStruct = statStruct;
        playerTransform = stat.gameObject.transform;
    }


    #endregion
    #region 딕셔너리 반환 부분
    public Dictionary<char, BuffData> ReturnDict(Dictionary<char, BuffData> dict) {return dict = BuffsArchive;}
    public Dictionary<char, AttackData> ReturnDict(Dictionary<char, AttackData> dict) { return dict = AttackArchive;}
    public Dictionary<char, PlayerStatStruct> ReturnDict(Dictionary<char, PlayerStatStruct> dict) { return dict = playerLastData; }


    private Dictionary<char, BuffData> BuffsArchive = new();
    private Dictionary<char, AttackData> AttackArchive = new();
    private Dictionary<char, PlayerStatStruct> playerLastData = new();
    #endregion
    private void Awake()
    {
        //SaveBuffJson();
        //SaveAttackJson();
        path = SetPass(StringManager.Instance.buffData);
        BuffsArchive = LoadJson<BuffStructure, char, BuffData>(path).MakeDict();
        foreach (var item in BuffsArchive)
        {
            UnityEngine.Debug.Log($"code:{item.Value}");
        }
        path = SetPass(StringManager.Instance.attakData);
        AttackArchive = LoadJson<AttackStructure, char, AttackData>(path).MakeDict();
        foreach (var item in AttackArchive)
        {
            UnityEngine.Debug.Log($"code:{item.Value}");
        }
    }
    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            //모든 데이터 초기화 및 관리
        }
    }
    public BuffStatEnum statEnum { get; set; }
    public void SaveBuffJson()
    {
        path = Path.Combine(Application.dataPath, StringManager.Instance.buffData) ?? "wrongPath";
        //string jsonData = null;

        File.WriteAllText(path, "");

        BuffStructure buffdata = new BuffStructure();

        for (int i = 0; i < buffCounts; i++)
        {
            BuffData buff = new BuffData((char)i, new BuffStat(1, 1, 1, 1), new CardInfo(statEnum = BuffStatEnum.empty, "1", "1", "1", "1", "1"));

            buffdata.buffDatas[i] = buff;
        }
        string jsonData = JsonUtility.ToJson(buffdata, true);
        File.WriteAllText(path, jsonData);
    }
    public AttackType attackType { get; set; }
    public AttackCardEnum attackEnum { get; set; }
    public void SaveAttackJson()
    {
        path = Path.Combine(Application.dataPath, StringManager.Instance.attakData) ?? "wrongPath";
        //string jsonData = null;
        if (path == null) return;

        File.WriteAllText(path, "");

        AttackStructure structure = new AttackStructure();

        for (int i = 0; i < 10; i++)
        {
            AttackData attackData = new AttackData((char)i, new AttackStatus(attackType, 1, 1, 1, 1, 1), new AttackCardInfo(attackEnum, "1", "1", "1", "1", "1"));

            structure.attackDatas[i] = attackData;

        }
        string jsonData = JsonUtility.ToJson(structure, true);
        File.WriteAllText(path, jsonData);
    }


    Loader LoadJson<Loader, Key, Value>(string path) where Loader : IDataLoader<Key, Value>
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log(path + "null or empty");
        }
        string jsonData = File.ReadAllText(path);
        //TextAsset textAsset= Resources.Load<TextAsset>(path);
        Loader data = JsonUtility.FromJson<Loader>(jsonData);
        Debug.Log(data);
        return data;
    }
    private string SetPass(string _path)
    {
        return path = Path.Join(Application.dataPath, _path);
    }
}


