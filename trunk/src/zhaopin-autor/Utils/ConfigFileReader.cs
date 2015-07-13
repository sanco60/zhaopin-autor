using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace MyFirstWebTest
{
    class ConfigFileReader
    {
        public ConfigFileReader(string szFileName)
        {
            m_fileName = szFileName;
            m_attrNames = new List<string>();
            m_valueRows = new List<List<string>>();
        }

        public bool read()
        {
            StreamReader _sr;
            try
            {
                _sr = new StreamReader(m_fileName, Encoding.Default);
            } 
            catch(System.IO.FileNotFoundException _ioe)
            {
                Console.WriteLine(_ioe);
                return false;
            }

            int iValueIndex = -1;
            string szLine;

            do
            {
                szLine = _sr.ReadLine();
                if (null == szLine)
                    break;

                if (0 > iValueIndex)
                {
                    disassembleLine(szLine, ref m_attrNames);
                    //属性行下一行跳过
                    szLine = _sr.ReadLine();
                }
                else
                {
                    m_valueRows.Add(new List<string>());
                    List<string> _curRow = m_valueRows[iValueIndex];
                    disassembleLine(szLine, ref _curRow);
                }
                iValueIndex = iValueIndex + 1;

            } while (null != szLine);

            return true;
        }

        public void disassembleLine(string szLine, ref List<string> list)
        {
            if (null == szLine || 0 == szLine.Length)
                return;

            if ('#' == szLine[0])
                return;

            char [] cSplits = {' ', '\t'};
            string[] szSplits = szLine.Split(cSplits);
            foreach(string _sz in szSplits)
            {
                if (AutorConstPool.NULL_STRING.Equals(_sz))
                {
                    list.Add("");
                } else
                {
                    if (0 != _sz.Length)
                        list.Add(_sz);
                }
            }
            return;
        }

        public List<List<string>> getValueRows()
        {
            return m_valueRows;
        }

        public List<string> getAttrNames()
        {
            return m_attrNames;
        }

        private string m_fileName;

        private List<string> m_attrNames;

        private List<List<string>> m_valueRows;
    }
}
