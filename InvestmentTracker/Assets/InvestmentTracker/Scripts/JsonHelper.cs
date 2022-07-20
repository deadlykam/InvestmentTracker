using System;
using UnityEngine;

namespace InvestmentTracker
{
    public static class JsonHelper
    {
        public static T FromJsonSingle<T>(string json)
        {
            WrapperSingle<T> wrapper = JsonUtility.FromJson<WrapperSingle<T>>(json);
            return wrapper.Item;
        }

        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T data)
        {
            WrapperSingle<T> wrapper = new WrapperSingle<T>();
            wrapper.Item = data;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable] private class Wrapper<T> { public T[] Items; }
        [Serializable] private class WrapperSingle<T> { public T Item; }
    }
}