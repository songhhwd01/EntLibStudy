﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace EntLibStudy.Helper
{
    [Serializable]
    public abstract class BaseClass<T> where T : class
    {
        public string ValidateTag { get; protected set; }

        public virtual bool IsValid()
        {
            var validateResults = Validation.Validate<T>(this as T);
            if (!validateResults.IsValid)
            {
                foreach (var item in validateResults)
                    ValidateTag += string.Format(@"{0}:{1}\n", item.Key, item.Message);
                return false;
            }
            return true;
        }
    }
}
