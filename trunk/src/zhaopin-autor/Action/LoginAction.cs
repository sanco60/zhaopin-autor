﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MyFirstWebTest
{
    class LoginAction
    {
        public LoginAction(Form1 m)
        {
            m_Form = m;
        }

        public bool start()
        {
            if (null == m_Form)
                return false;

            UserManager _ua = UserManager.instance();
            SUserAccount _account = _ua.getUserAccount();
            if (null == _account)
                return false;

            string _loginUrl = "http://www.zhaopin.com/";

            string _userNameId = "loginname";
            string _passWordId = "password";
            int _webID = WebElementPool.WEB1_ID;

            Attribute _loginKey;
            
            _loginKey.szKey = WebElementPool.TYPE;
            _loginKey.szValue = "submit";

            m_Form.navigate(_webID, _loginUrl, 15000);
            m_Form.setAttribute(_webID, _userNameId, _account.szID);
            m_Form.setAttribute(_webID, _passWordId, _account.szPassword);
            
            m_Form.invokeMember(_webID, WebElementPool.BUTTON, _loginKey, WebElementPool.CLICK);
            m_Form.wait(_webID, 0);

            do
            {
                m_Form.wait(_webID, 3000);
                string _szUrl = m_Form.getCurUrl(_webID);
                string _szMarkLogin = "login";
                if (-1 == _szUrl.IndexOf(_szMarkLogin))
                    break;

                /* 验证码登陆界面 */
                string _szLoginName = "LoginName";
                string _szPassword = "Password";
                string _szTextCode = null;

                Attribute _aValidImg, _aLoginBtn, _aCheckCode;
                _aValidImg.szKey = WebElementPool.ID;
                _aValidImg.szValue = "checkimg";
                _aLoginBtn.szKey = WebElementPool.ID;
                _aLoginBtn.szValue = "loginbutton";
                _aCheckCode.szKey = WebElementPool.ID;
                _aCheckCode.szValue = "CheckCode";

                m_Form.setAttribute(_webID, _szLoginName, _account.szID);
                m_Form.setAttribute(_webID, _szPassword, _account.szPassword);

                m_Form.displayElem(_webID, WebElementPool.IMG, _aValidImg);
                do
                {
                    _szTextCode = m_Form.getTextCode();
                    if (null != _szTextCode)
                    {
                        if (4 == _szTextCode.Length)
                            break;
                    }
                    m_Form.wait(_webID, 3000);

                } while (true);

                m_Form.setAttribute(_webID, _aCheckCode.szValue, _szTextCode);
                m_Form.invokeMember(_webID, WebElementPool.INPUT, _aLoginBtn, WebElementPool.CLICK);
                m_Form.wait(_webID, 0);

            } while (true);

            m_Form.wait(_webID, 3000);
            m_Form.invokeMember2(_webID, WebElementPool.SPAN, "popup_close", WebElementPool.CLICK);

            Console.WriteLine("===Login over.===");
            return true;
        }

        private Form1 m_Form;
    }
}
