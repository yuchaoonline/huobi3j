
using System;
namespace ADeeWu.HuoBi3J.Model
{

    public class CP_Keyword_Result_Click
    {

        #region Fields
        private long _ID = 0L;
        private long? _KeywordResultID = null;
        private DateTime? _ClickTime = null;
        private string _ClickIP = null;
        #endregion

        #region Contructors
        public CP_Keyword_Result_Click()
        {
        }

        public CP_Keyword_Result_Click
        (
            long iD,
                long keywordResultID,
                DateTime clickTime,
                string clickIP
        )
        {
            _ID = iD;
            _KeywordResultID = keywordResultID;
            _ClickTime = clickTime;
            _ClickIP = clickIP;

        }
        #endregion

        public long ID { set { _ID = value; } get { return _ID; } }
        public long? KeywordResultID { set { _KeywordResultID = value; } get { return _KeywordResultID; } }
        public DateTime? ClickTime { set { _ClickTime = value; } get { return _ClickTime; } }
        public string ClickIP { set { _ClickIP = value; } get { return _ClickIP; } }
    }
}

