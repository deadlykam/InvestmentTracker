using System.IO;
using UnityEngine;

namespace InvestmentTracker.Core
{
    public static class SaveLoad
    {
        private static Element[] _dataElements;
        private static string _persistentPath;
        private static string _fileName;
        private static string _path;
        private static string _json;
        private static bool _isInit = false;

        public static void Initialize()
        {
            _persistentPath = $"{Application.persistentDataPath}{Path.AltDirectorySeparatorChar}";
            _fileName = "DefaultSave.json";
            _isInit = true;
        }

        public static void SaveData(Element[] data)
        {
            if (!_isInit) Initialize();
            _path = $"{_persistentPath}{_fileName}";
            Debug.Log($"Save -> {_path}");
            _json = JsonHelper.ToJson(data);
            Debug.Log(_json);

            using StreamWriter writer = new StreamWriter(_path);
            writer.Write(_json);
        }

        public static Element[] LoadData()
        {
            if (!_isInit) Initialize();
            _path = $"{_persistentPath}{_fileName}";
            using StreamReader reader = new StreamReader(_path);
            _json = reader.ReadToEnd();
            _dataElements = JsonHelper.FromJson<Element>(_json);
            return _dataElements;
        }
    }
}