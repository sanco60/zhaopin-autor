using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    abstract class DatabaseObj
    {
        public DatabaseObj() 
        {
            m_AttrValues = new Dictionary<string, string>();
        }

        public void pick(ref Object t)
        {
            try
            {
                innerPick(ref t);
            }
            catch(System.InvalidCastException _e)
            {
                Console.WriteLine(_e);
            }
        }

        public void put(ref Object t)
        {
            try
            {
                innerPut(ref t);
            }
            catch (System.InvalidCastException _e)
            {
                Console.WriteLine(_e);
            }
        }

        protected abstract void innerPick(ref Object t);

        protected abstract void innerPut(ref Object t);

        public abstract string getTitle();

        public abstract DatabaseObj clone();

        public void getValue(string szAttr, out string szValue)
        {
            if (null == m_AttrValues)
            {
                szValue = "";
                return;
            }
            try
            {
                szValue = m_AttrValues[szAttr];
            } 
            catch(System.Collections.Generic.KeyNotFoundException e)
            {
                szValue = "";
            }
            return;
        }

        public void setValue(string szAttr, string szValue)
        {
            if (null == m_AttrValues)
                return;

            m_AttrValues[szAttr] = szValue;
            //m_AttrValues.Add(szAttr, szValue);
            return;
        }        

        protected Dictionary<string, string> m_AttrValues;
    }

}
