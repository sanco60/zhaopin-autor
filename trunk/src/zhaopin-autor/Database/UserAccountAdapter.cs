using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class UserAccountAdapter : DatabaseObj
    {
        private const string c_Title = "UserAccount";

        private const string c_AttrID = "id";
        private const string c_AttrPassword = "password";

        public UserAccountAdapter()
        {
            m_AttrValues.Add(c_AttrID, "");
            m_AttrValues.Add(c_AttrPassword, "");
        }

        public UserAccountAdapter(SUserAccount ua)
        {
            m_AttrValues.Add(c_AttrID, ua.szID);
            m_AttrValues.Add(c_AttrPassword, ua.szPassword);
        }

        protected override void innerPick(ref Object t)
        {
            SUserAccount _ua = (SUserAccount)t;
            m_AttrValues[c_AttrID] = _ua.szID;
            m_AttrValues[c_AttrPassword] = _ua.szPassword;
        }

        protected override void innerPut(ref Object t)
        {
            SUserAccount _ua = (SUserAccount)t;
            _ua.szID = m_AttrValues[c_AttrID];
            _ua.szPassword = m_AttrValues[c_AttrPassword];
        }

        public override string getTitle()
        {
            return c_Title;
        }

        public override DatabaseObj clone()
        {
            UserAccountAdapter _uaa = new UserAccountAdapter();

            return _uaa;
        }

    }
}
