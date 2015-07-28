using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyFirstWebTest
{
    class ApplyAction
    {
        public ApplyAction(Form1 f)
        {
            m_Form = f;
            m_FilterAction = new FilterAction(f);
        }

        public bool start()
        {
            if (null == m_Form)
                return false;

            int _webID = WebElementPool.WEB1_ID;
            string _szJobRegex = @"href=http://jobs.zhaopin.com/";
            string _szCoRegex = @"href=http://company.zhaopin.com/";
            string _szCoDetailsPattern = "公司规模";
            string _szCheckRegex = "type=checkbox";
            string _szCoName = "";
            string _szJobName = "";
            string _szCoDetails = "";
            string _szBtnApply = "申请职位";
            string _szBtnNext = @"/pageron.gif";
            string _szScalePattern = @"\d+(?=人)";

            Attribute _attr, _classPattern, _btnClose;
            _attr.szKey = WebElementPool.HREF;
            _attr.szValue = "";
            _classPattern.szKey = WebElementPool.CLASS;
            _classPattern.szValue = "newlist";
            _btnClose.szKey = WebElementPool.TITLE;
            _btnClose.szValue = "关闭";

            Regex _rg = new Regex(_szScalePattern);
            bool bNext = false;
            do {
                m_Form.cacheElements2(_webID, WebElementPool.TABLE, _classPattern);
                int _count = m_Form.cacheCount();
                if (0 == _count)
                {
                    Console.WriteLine("Error: cache wrong!");
                    continue;
                }
                for (int _i = 0; _i < _count; _i ++)
                {
                    //获取职位名称
                    m_Form.cacheIndexText(_i, WebElementPool.A, _szJobRegex, ref _szJobName);
                    //获取公司名称
                    m_Form.cacheIndexText(_i, WebElementPool.A, _szCoRegex, ref _szCoName);

                    //获取公司规模
                    m_Form.cacheIndexText(_i, WebElementPool.SPAN, _szCoDetailsPattern, ref _szCoDetails);
                    string _szCorpMaxSize = _rg.Match(_szCoDetails).ToString();
                    
                    m_FilterAction.setContent(EFilter.JobName, _szJobName);
                    m_FilterAction.setContent(EFilter.CoName, _szCoName);
                    m_FilterAction.setContent(EFilter.CoSize, _szCorpMaxSize);

                    if (m_FilterAction.isPass())
                    {
                        m_Form.cacheInvokeMember(_i, WebElementPool.INPUT, _szCheckRegex, WebElementPool.CLICK);
                    } else
                    {
                        //Console.WriteLine("No {0}, {1}, {2}", _szCoName, _szCorpMaxSize, _szJobName);
                    }
                }
                //点击申请选中职位
                m_Form.invokeMember2(_webID, WebElementPool.A, _szBtnApply, WebElementPool.CLICK);
                m_Form.wait(_webID, 3000);

                //点击忽略
                m_Form.invokeMember2(_webID, WebElementPool.SPAN, "忽略", WebElementPool.CLICK);
                m_Form.wait(_webID, 3000);

                //关闭弹出子窗口
                m_Form.invokeMember(_webID, WebElementPool.A, _btnClose, WebElementPool.CLICK);
                m_Form.wait(_webID, 3000);

                //点击下一页
                bNext = m_Form.invokeMember2(_webID, WebElementPool.A, _szBtnNext, WebElementPool.CLICK);
                if (bNext)
                    m_Form.wait(_webID, 0);

            } while (bNext);
            
            Console.WriteLine("===ApplyAction over.===");
            return true;
        }

        private Form1 m_Form;

        private FilterAction m_FilterAction;
    }
}
