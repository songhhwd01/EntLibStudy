using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using EntLibStudy.IDAL;
using EntLibStudy.Helper;

namespace EntLibStudy.Factory
{
    public static class DataAccess<T>
    {
        private static readonly string assemblyString = ConfigurationManager.AppSettings["DAL"];

        /// <summary>
        /// 通用对象反射(包含缓存)
        /// </summary>
        /// <param name="className">要反射的类名</param>
        /// <returns></returns>
        public static T CreateObject(string className)
        {
            var typeName = assemblyString + "." + className;
            //判断对象是否被缓存,如果已经缓存则直接从缓存中读取,反之则直接反射并缓存
            var obj = (T)CacheHelper.GetCache(typeName);
            if (obj == null)
            {
                obj = (T)Assembly.Load(assemblyString).CreateInstance(typeName, true);
                CacheHelper.Add(typeName, obj, true);
            }
            return obj;
        }

        public static IClassInfoService CreateClassInfo()
        {
            string typeName = assemblyString + ".ClassInfoService";
            //判断对象是否被缓存,如果已经缓存则直接从缓存中读取,反之则直接反射并缓存
            if (CacheHelper.GetCache(typeName) != null)
            {
                return (IClassInfoService)CacheHelper.GetCache(typeName);
            }
            else
            {
                IClassInfoService service = (IClassInfoService)Assembly.Load(assemblyString).CreateInstance(typeName, true);
                CacheHelper.Add(typeName, service, true);
                return service;
            }
        }

        public static IStudentService CreateStudent()
        {
            string typeName = assemblyString + ".StudentService";
            if (CacheHelper.GetCache(typeName) != null)
            {
                return (IStudentService)CacheHelper.GetCache(typeName);
            }
            else
            {
                IStudentService service = (IStudentService)Assembly.Load(assemblyString).CreateInstance(typeName, true);
                CacheHelper.Add(typeName, service, true);
                return service;
            }
        }

        public static ISubjectService CreateSubject()
        {
            string typeName = assemblyString + ".SubjectService";
            if (CacheHelper.GetCache(typeName) != null)
            {
                return (ISubjectService)CacheHelper.GetCache(typeName);
            }
            else
            {
                ISubjectService service = (ISubjectService)Assembly.Load(assemblyString).CreateInstance(typeName, true);
                CacheHelper.Add(typeName, service, true);
                return service;
            }
        }

        public static ISubjectAndStudentService CreateSubjectAndStudent()
        {
            string typeName = assemblyString + ".SubjectAndStudentService";
            if (CacheHelper.GetCache(typeName) != null)
            {
                return (ISubjectAndStudentService)CacheHelper.GetCache(typeName);
            }
            else
            {
                ISubjectAndStudentService service = (ISubjectAndStudentService)Assembly.Load(assemblyString).CreateInstance(typeName, true);
                CacheHelper.Add(typeName, service, true);
                return service;
            }
        }
    }
}
