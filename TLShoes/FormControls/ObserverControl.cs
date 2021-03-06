﻿using System;
using System.Collections.Generic;
using System.Linq;
using TLShoes.Common;

namespace TLShoes
{
    public class ObserverControl
    {
        private static List<EventObserver> RegisterList = new List<EventObserver>();
        private static List<EventObserverParam> RegisterParamList = new List<EventObserverParam>();

        public static void Regist(Define.ActionType registerPublish, string registerSubscrire, Action action)
        {
            var register = RegisterList.FirstOrDefault(s => s.RegisterPublish == registerPublish && s.RegisterSubcrise == registerSubscrire && s.Action == action);
            if (register == null)
            {
                register = new EventObserver(registerPublish, registerSubscrire, action);
                RegisterList.Add(register);
            }
        }

        public static void Regist(Define.ActionType registerPublish, string registerSubscrire, Action<object> action)
        {
            var register = RegisterParamList.FirstOrDefault(s => s.RegisterPublish == registerPublish && s.RegisterSubcrise == registerSubscrire);
            if (register == null)
            {
                register = new EventObserverParam(registerPublish, registerSubscrire, action);
                RegisterParamList.Add(register);
            }
        }

        public static void Clear()
        {
            RegisterList.Clear();
            RegisterParamList.Clear();
        }


        public static void Detacth(string registerName)
        {
            RegisterList.RemoveAll(s => s.RegisterSubcrise == registerName);
        }

        public static void PulishAction(Define.ActionType publish, object data = null)
        {
            var listAction = RegisterList.Where(s => s.RegisterPublish == publish && s.RegisterSubcrise == Main.currentForm).ToList();
            foreach (var item in listAction)
            {
                item.Action();
            }

            var listParamAction = RegisterParamList.Where(s => s.RegisterPublish == publish && s.RegisterSubcrise == Main.currentForm).ToList();
            foreach (var item in listParamAction)
            {
                if (data != null)
                {
                    item.Action(data);
                }
            }

        }

        private class EventObserver
        {
            public Define.ActionType RegisterPublish;
            public string RegisterSubcrise;
            public Action Action;

            public EventObserver(Define.ActionType registerPublish, string registerSubcrise, Action action)
            {
                RegisterPublish = registerPublish;
                RegisterSubcrise = registerSubcrise;
                Action = action;
            }
        }

        private class EventObserverParam
        {
            public Define.ActionType RegisterPublish;
            public string RegisterSubcrise;
            public Action<object> Action;

            public EventObserverParam(Define.ActionType registerPublish, string registerSubcrise, Action<object> action)
            {
                RegisterPublish = registerPublish;
                RegisterSubcrise = registerSubcrise;
                Action = action;
            }
        }
    }
}
