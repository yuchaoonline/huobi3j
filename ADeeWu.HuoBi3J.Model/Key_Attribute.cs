
using System;
namespace ADeeWu.HuoBi3J.Model
{

    public class Key_Attribute
    {

        #region Fields
        private int _ID = 0;
        private int? _KID = null;
        private string _DataType = null;
        private string _DataValue = null;
        #endregion

        #region Contructors
        public Key_Attribute()
        {
        }

        public Key_Attribute
        (
            int iD,
                int kID,
                string dataType,
                string dataValue
        )
        {
            _ID = iD;
            _KID = kID;
            _DataType = dataType;
            _DataValue = dataValue;

        }
        #endregion

        public int ID { set { _ID = value; } get { return _ID; } }
        public int? KID { set { _KID = value; } get { return _KID; } }
        public string DataType { set { _DataType = value; } get { return _DataType; } }
        public string DataValue { set { _DataValue = value; } get { return _DataValue; } }
    }
}

