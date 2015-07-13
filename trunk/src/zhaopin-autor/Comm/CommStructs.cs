using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    enum ESearchCata
    {
        EJobName,
        ECoName,
        EContent
    }

    enum EDatabaseType
    {
        EUserAccount,
        ESearchFactor,
        EForbiddenCorp
    }

    class SUserAccount
    {
        public string szID;
        public string szPassword;
    }

    class SSearchFactor
    {
        public string szSearchText;
        public ESearchCata eSearchCata;
    }

    class SForbiddenCorp
    {
        public string szCorpName;
    }

}

