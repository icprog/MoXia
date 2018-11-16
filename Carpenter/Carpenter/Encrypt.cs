
using System . Data;
using System . Text;

namespace Carpenter
{
    public class Encrypt
    {
        public static string encryPt ( string plainText ,string keyValue )
        {
            int len = keyValue.Length - 1;
            int _moveIndex = 0;
            string _result = string.Empty;
            
            for ( int i = 0 ; i < plainText.Length ; i++ )
            {
                _moveIndex = keyValue.LastIndexOf( plainText[i] ) + i + 1 > len ?
                            ( ( keyValue.LastIndexOf( plainText[i] ) + i + 1 ) % len ) - 1 :
                            ( keyValue.LastIndexOf( plainText[i] ) + i + 1 ) % len;
                _result += keyValue.Substring( _moveIndex ,1 );
            }
            return _result;
        }


    }
}
