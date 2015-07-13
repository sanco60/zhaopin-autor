using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class FlashAction
    {
        public FlashAction(Form1 f)
        {
            m_Form = f;
        }

        public bool start()
        {
            int _webId = WebElementPool.WEB1_ID;
            string _szRefreshClose = @"Refresh_success_LastUpdate";
            Attribute _aBtnRefresh, _aBtnSave, _aResumeManage, _btnCareerSearch;

            _aResumeManage.szKey = WebElementPool.HREF;
            _aResumeManage.szValue = "CV_CResumeManage.php";
            _aBtnRefresh.szKey = WebElementPool.CLASS;
            _aBtnRefresh.szValue = "iconRefresh";
            _aBtnSave.szKey = WebElementPool.CLASS;
            _aBtnSave.szValue = "panel_btn_s";

            _btnCareerSearch.szKey = WebElementPool.HREF;
            _btnCareerSearch.szValue = "advance_search.php";

            m_Form.invokeMember(_webId, WebElementPool.A, _aResumeManage, WebElementPool.CLICK);
            m_Form.wait(_webId, 15000);

            m_Form.cacheElements2(_webId, WebElementPool.A, _aBtnRefresh);
            for (int _i = 0; _i < m_Form.cacheCount(); _i++)
            {
                m_Form.cacheInvokeMemberD(_i, WebElementPool.CLICK);
                m_Form.wait(_webId, 3000);
                //Console.WriteLine("点击确定");
                m_Form.invokeMember(_webId, WebElementPool.A, _aBtnSave, WebElementPool.CLICK);
                m_Form.wait(_webId, 3000);
                //Console.WriteLine("点击关闭");
                m_Form.invokeMember2(_webId, WebElementPool.A, _szRefreshClose, WebElementPool.CLICK);
            }

            //点击搜索职位
            m_Form.invokeMember(_webId, WebElementPool.A, _btnCareerSearch, WebElementPool.CLICK);
            m_Form.wait(_webId, 5000);

            Console.WriteLine("===FlashAction over.===");
            return true;
        }

        private Form1 m_Form;
    }
}
