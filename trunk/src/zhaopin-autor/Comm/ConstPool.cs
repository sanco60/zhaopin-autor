using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    public static class DatabasePool
    {
        /*****  database *******/
        public const string USERNAME = "username";
        public const string PASSWORD = "password";

        /*****  database end *******/

        
    }

    public static class WebElementPool
    {
        public const int WEB1_ID = 1;
        public const int WEB2_ID = 2;

        public const string VALUE = "value";
        public const string ID = "id";
        public const string INPUT = "input";
        public const string A = "a";
        public const string LI = "li";
        public const string TD = "td";
        public const string SRC = "src";
        public const string HREF = "href";
        public const string CLASS = "className";
        public const string IMG = "img";
        public const string SPAN = "span";
        public const string TARGET = "target";
        public const string TR = "tr";
        public const string ALIGN = "align";
        public const string NAME = "name";
        public const string ALT = "alt";
        public const string TITLE = "title";
        public const string CCTYPE = "cctype";
        public const string TYPE = "type";
        public const string BUTTON = "button";
        public const string URL = "url";

        public const string CLICK = "click";
        //public const string MOUSEMOVE = "mousemove";
        
    }

    public static class AutorConstPool
    {
        public const string FILE_SUFFIX = ".txt";
        public const string NULL_STRING = "\"\"";
        public const string DATABASEPATH = "database/";
    }

    public struct Attribute
    {
        public string szKey;
        public string szValue;
    }
}
