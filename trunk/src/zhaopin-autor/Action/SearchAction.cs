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

            string _szJobTitle = "职位名";
            string _szCoTitle = "公司名";

            Attribute _inJobarea, _areaValue;

            _inJobarea.szKey = WebElementPool.ID;
            _inJobarea.szValue = "JobLocation";
            _areaValue.szKey = WebElementPool.TITLE;
            _areaValue.szValue = "";

            //选择搜索类
            if (ESearchCata.EJobName == m_SearchFactor.eSearchCata)
            {
                m_Form.invokeMember2(_webID, WebElementPool.A, _szJobTitle, WebElementPool.CLICK);
            }
            else if (ESearchCata.ECoName == m_SearchFactor.eSearchCata)
            {
                m_Form.invokeMember2(_webID, WebElementPool.A, _szCoTitle, WebElementPool.CLICK);
            }
            else
            {
                return false;
            }

            //选择地区
            m_Form.getAttribute(_webID, WebElementPool.INPUT, _inJobarea, ref _areaValue);
            if (_areaValue.szValue != "武汉")
            {
                Attribute _aJobarea, _aConfirm, _aWuhan;
                _aJobarea.szKey = WebElementPool.ID;
                _aJobarea.szValue = "buttonSelCity";
                _aWuhan.szKey = WebElementPool.INAME;
                _aWuhan.szValue = "武汉";
                _aConfirm.szKey = WebElementPool.ONCLICK;
                _aConfirm.szValue = "fnClickOk";

                m_Form.invokeMember(_webID, WebElementPool.INPUT, _aJobarea, WebElementPool.CLICK);
                m_Form.wait(_webID, 3000);
                m_Form.invokeMember(_webID, WebElementPool.INPUT, _aWuhan, WebElementPool.CLICK);
                m_Form.wait(_webID, 3000);
                m_Form.invokeMember(_webID, WebElementPool.SPAN, _aConfirm, WebElementPool.CLICK);
                m_Form.wait(_webID, 3000);
            }

            Attribute _inputValue, _inputKeyAttr, _btnSearch;

            _inputKeyAttr.szKey = WebElementPool.ID;
            _inputKeyAttr.szValue = "KeyWord_kw2";
            _inputValue.szKey = WebElementPool.VALUE;
            _inputValue.szValue = m_SearchFactor.szSearchText;

            _btnSearch.szKey = WebElementPool.CLASS;
            _btnSearch.szValue = "doesSearch";

            //填入搜索关键字
            m_Form.setAttribute(_webID, WebElementPool.INPUT, _inputKeyAttr, _inputValue);

            //点击搜索按钮            
            m_Form.invokeMember(_webID, WebElementPool.BUTTON, _btnSearch, WebElementPool.CLICK);

            m_Form.wait(_webID, 0);

            Console.WriteLine("===Search over.===");
            return true;
        }

        private Form1 m_Form;

        private SSearchFactor m_SearchFactor;

        //private SSearchFactor m_SearchFactor;
    }    

    
}
