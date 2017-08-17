using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectsAndTypes
{
    public class Car
    {
        private string _description;
        private uint _nWheels;
        public Car(string description)
        {
            _description = description;
            _nWheels = 4;
        }
        public Car(string description, uint nWheels)
        {
            _description = description;
            _nWheels = nWheels;
        }
    }

    /// <summary>
    /// 从构造函数中调用其他构造函数
    /// </summary>
    public class Car2
    {
        private string _description;
        private uint _nWheels;

        //以下：this关键字调用参数最匹配的那个构造函数
        public Car2(string description):this(description,4)
        {
        }
        public Car2(string description, uint nWheels)
        {
            _description = description;
            _nWheels = nWheels;
        }
    }
}
