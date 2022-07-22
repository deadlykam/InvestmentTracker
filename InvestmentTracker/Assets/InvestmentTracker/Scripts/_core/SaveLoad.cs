using System.IO;
using UnityEngine;

namespace InvestmentTracker.Core
{
    public static class SaveLoad
    {
        private static Element[] _dataElements;
        private static float _dataFloat;
        private static string _persistentPath;
        private static string _path;
        private static string _json;
        private static bool _isInit = false;

        public static void Initialize()
        {
            _persistentPath = $"{Application.persistentDataPath}{Path.AltDirectorySeparatorChar}";
            _isInit = true;
        }

        public static void SaveData(Element[] data, string fileName)
        {
            if (!_isInit) Initialize();
            _path = $"{_persistentPath}{fileName}";
            _json = JsonHelper.ToJson(data);

            using StreamWriter writer = new StreamWriter(_path);
            writer.Write(_json);
        }

        public static void SaveData(float data, string fileName)
        {
            if (!_isInit) Initialize();
            _path = $"{_persistentPath}{fileName}";
            _json = JsonHelper.ToJson(data);

            using StreamWriter writer = new StreamWriter(_path);
            writer.Write(_json);
        }

        public static Element[] LoadData(string fileName)
        {
            if (!_isInit) Initialize();
            _path = $"{_persistentPath}{fileName}";

            if (File.Exists(_path)) // Checking if path exists
            {
                using StreamReader reader = new StreamReader(_path);
                _json = reader.ReadToEnd();
                _dataElements = JsonHelper.FromJson<Element>(_json);
                return _dataElements;
            }

            return null;
        }

        public static float LoadDataFloat(string fileName)
        {
            if (!_isInit) Initialize();
            _path = $"{_persistentPath}{fileName}";

            if (File.Exists(_path)) // Checking if path exists
            {
                using StreamReader reader = new StreamReader(_path);
                _json = reader.ReadToEnd();
                return JsonHelper.FromJsonSingle<float>(_json);
            }

            return 0;
        }

        public static bool IsFileExist(string fileName)
        {
            if (!_isInit) Initialize();
            _path = $"{_persistentPath}{fileName}";
            return File.Exists(_path);
        }
    }
}