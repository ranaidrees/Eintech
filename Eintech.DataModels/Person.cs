using Eintech.Common;
using System;

namespace Eintech.DataModels
{
    public class Person : BaseDataModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
    }
}
