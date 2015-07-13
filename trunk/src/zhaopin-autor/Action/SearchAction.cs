using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class SearchAction
    {
        public SearchAction(Form1 m)
        {
            m_Form = m;
        }

        public void setSearchFactor(SSearchFactor sf)
        {
            m_SearchFactor = sf;
        }

        public bool start()
        {
            if (null == m_Form || null == m_SearchFactor)
                return false;

            int _webID = WebElementPool.WEB1_ID;

            Attribute _btnJobName, _btnCoName, _btnJobarea, _areaValue;

            _btnJobName.szKey = WebElementPool.TITLE;
            _btnJobName.szValue = "仅搜职位名关键字";
            _btnCoName.szKey = WebElementPool.TITLE;
            _btnCoName.szValue = "仅搜公司名关键字";
            _btnJobarea.szKey = WebElementPool.NAME;
            _btnJobarea.szValue = "btnJobarea";
            _areaValue.szKey = WebElementPool.VALUE;
            _areaValue.szValue = "";

            //选择搜索类
            if (ESearchCata.EJobName == m_SearchFactor.eSearchCata)
            {
                m_Form.invokeMember(_webID, WebElementPool.LI, _btnJobName, WebElementPool.CLICK);
            }
            else if (ESearchCata.ECoName == m_SearchFactor.eSearchCata)
            {
                m_Form.invokeMember(_webID, WebElementPool.LI, _btnCoName, WebElementPool.CLICK);
            }
            else
            {
                return false;
            }

            //选择地区
            m_Form.getAttribute(_webID, WebElementPool.INPUT, _btnJobarea, ref _areaValue);
            if (_areaValue.szValue != "武汉")
            {
                Attribute _aConfirm, _aWuhan;
                _aConfirm.szKey = WebElementPool.CCTYPE;
                _aConfirm.szValue = "confirm";
                _aWuhan.szKey = WebElementPool.NAME;
                _aWuhan.szValue = @"JL\d+180200";

                m_Form.invokeMember(_webID, WebElementPool.INPUT, _btnJobarea, WebElementPool.CLICK);
                m_Form.wait(_webID, 3000);
                m_Form.invokeMember(_webID, WebElementPool.INPUT, _aWuhan, WebElementPool.CLICK);
                m_Form.wait(_webID, 3000);
                m_Form.invokeMember(_webID, WebElementPool.SPAN, _aConfirm, WebElementPool.CLICK);
                m_Form.wait(_webID, 3000);
            }

            Attribute _inputValue, _inputKeyAttr, _btnSearch;

            _inputKeyAttr.szKey = WebElementPool.ID;
            _inputKeyAttr.szValue = "kwdselectid";
            _inputValue.szKey = WebElementPool.VALUE;
            _inputValue.szValue = m_SearchFactor.szSearchText;

            _btnSearch.szKey = WebElementPool.SRC;
            _btnSearch.szValue = "jsearch.gif";

            //填入搜索关键字
            m_Form.setAttribute(_webID, WebElementPool.INPUT, _inputKeyAttr, _inputValue);

            //点击搜索按钮            
            m_Form.invokeMember(_webID, WebElementPool.INPUT, _btnSearch, WebElementPool.CLICK);

            m_Form.wait(_webID, 30000);

            Console.WriteLine("===Search over.===");
            return true;
        }

        private Form1 m_Form;

        private SSearchFactor m_SearchFactor;

        //private SSearchFactor m_SearchFactor;
    }    

    
}
