﻿namespace UILibrary.Win32
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Text;

    public class HttpWebRequestHelper
    {
        private System.Text.Encoding encoding = System.Text.Encoding.UTF8;

        public byte[] CreateFieldData(string fieldName, string fieldValue)
        {
            string s = string.Format(this.Boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n", fieldName, fieldValue);
            return this.encoding.GetBytes(s);
        }

        public byte[] CreateFieldData(string fieldName, string filename, string contentType, byte[] fileBytes)
        {
            string s = "\r\n";
            string str2 = string.Format(this.Boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", fieldName, filename, contentType);
            byte[] bytes = this.encoding.GetBytes(str2);
            byte[] buffer2 = this.encoding.GetBytes(s);
            byte[] array = new byte[(bytes.Length + fileBytes.Length) + buffer2.Length];
            bytes.CopyTo(array, 0);
            fileBytes.CopyTo(array, bytes.Length);
            buffer2.CopyTo(array, (int) (bytes.Length + fileBytes.Length));
            return array;
        }

        public System.Text.Encoding GetEncoding(HttpWebResponse response)
        {
            string contentEncoding = response.ContentEncoding;
            System.Text.Encoding encoding = System.Text.Encoding.Default;
            if (contentEncoding == "")
            {
                string contentType = response.ContentType;
                if (contentType.ToLower().IndexOf("charset") != -1)
                {
                    contentEncoding = contentType.Substring(contentType.ToLower().IndexOf("charset=") + "charset=".Length);
                }
            }
            if (contentEncoding != "")
            {
                try
                {
                    encoding = System.Text.Encoding.GetEncoding(contentEncoding);
                }
                catch
                {
                }
            }
            return encoding;
        }

        private static int HexToInt(char h)
        {
            if ((h >= '0') && (h <= '9'))
            {
                return (h - '0');
            }
            if ((h >= 'a') && (h <= 'f'))
            {
                return ((h - 'a') + 10);
            }
            if ((h >= 'A') && (h <= 'F'))
            {
                return ((h - 'A') + 10);
            }
            return -1;
        }

        public static char IntToHex(int n)
        {
            if (n <= 9)
            {
                return (char) (n + 0x30);
            }
            return (char) ((n - 10) + 0x61);
        }

        public static bool IsSafe(char ch)
        {
            if ((((ch >= 'a') && (ch <= 'z')) || ((ch >= 'A') && (ch <= 'Z'))) || ((ch >= '0') && (ch <= '9')))
            {
                return true;
            }
            switch (ch)
            {
                case '\'':
                case '(':
                case ')':
                case '*':
                case '-':
                case '.':
                case '_':
                case '!':
                    return true;
            }
            return false;
        }

        public byte[] JoinBytes(ArrayList byteArrays)
        {
            int num = 0;
            int index = 0;
            string s = this.Boundary + "--\r\n";
            byte[] bytes = this.encoding.GetBytes(s);
            byteArrays.Add(bytes);
            foreach (byte[] buffer2 in byteArrays)
            {
                num += buffer2.Length;
            }
            byte[] array = new byte[num];
            foreach (byte[] buffer4 in byteArrays)
            {
                buffer4.CopyTo(array, index);
                index += buffer4.Length;
            }
            return array;
        }

        public string TextContent(HttpWebResponse response)
        {
            string str;
            string str2 = "";
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, this.GetEncoding(response));
            while ((str = reader.ReadLine()) != null)
            {
                str2 = str2 + str + "\r\n";
            }
            responseStream.Close();
            return str2;
        }

        public static string UrlDecode(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlDecode(str, System.Text.Encoding.UTF8);
        }

        public static string UrlDecode(string str, System.Text.Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            return UrlDecodeStringFromStringInternal(str, e);
        }

        private static string UrlDecodeStringFromStringInternal(string s, System.Text.Encoding e)
        {
            int length = s.Length;
            UrlDecoder decoder = new UrlDecoder(length, e);
            for (int i = 0; i < length; i++)
            {
                char ch = s[i];
                if (ch == '+')
                {
                    ch = ' ';
                }
                else if ((ch == '%') && (i < (length - 2)))
                {
                    if ((s[i + 1] == 'u') && (i < (length - 5)))
                    {
                        int num3 = HexToInt(s[i + 2]);
                        int num4 = HexToInt(s[i + 3]);
                        int num5 = HexToInt(s[i + 4]);
                        int num6 = HexToInt(s[i + 5]);
                        if (((num3 < 0) || (num4 < 0)) || ((num5 < 0) || (num6 < 0)))
                        {
                            goto Label_0106;
                        }
                        ch = (char) ((((num3 << 12) | (num4 << 8)) | (num5 << 4)) | num6);
                        i += 5;
                        decoder.AddChar(ch);
                        continue;
                    }
                    int num7 = HexToInt(s[i + 1]);
                    int num8 = HexToInt(s[i + 2]);
                    if ((num7 >= 0) && (num8 >= 0))
                    {
                        byte b = (byte) ((num7 << 4) | num8);
                        i += 2;
                        decoder.AddByte(b);
                        continue;
                    }
                }
            Label_0106:
                if ((ch & 0xff80) == 0)
                {
                    decoder.AddByte((byte) ch);
                }
                else
                {
                    decoder.AddChar(ch);
                }
            }
            return decoder.GetString();
        }

        public static string UrlEncode(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlEncode(str, System.Text.Encoding.UTF8);
        }

        public static string UrlEncode(string str, System.Text.Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            return System.Text.Encoding.ASCII.GetString(UrlEncodeToBytes(str, e));
        }

        private static byte[] UrlEncodeBytesToBytesInternal(byte[] bytes, int offset, int count, bool alwaysCreateReturnValue)
        {
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < count; i++)
            {
                char ch = (char) bytes[offset + i];
                if (ch == ' ')
                {
                    num++;
                }
                else if (!IsSafe(ch))
                {
                    num2++;
                }
            }
            if ((!alwaysCreateReturnValue && (num == 0)) && (num2 == 0))
            {
                return bytes;
            }
            byte[] buffer = new byte[count + (num2 * 2)];
            int num4 = 0;
            for (int j = 0; j < count; j++)
            {
                byte num6 = bytes[offset + j];
                char ch2 = (char) num6;
                if (IsSafe(ch2))
                {
                    buffer[num4++] = num6;
                }
                else if (ch2 == ' ')
                {
                    buffer[num4++] = 0x2b;
                }
                else
                {
                    buffer[num4++] = 0x25;
                    buffer[num4++] = (byte) IntToHex((num6 >> 4) & 15);
                    buffer[num4++] = (byte) IntToHex(num6 & 15);
                }
            }
            return buffer;
        }

        public static byte[] UrlEncodeToBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            return UrlEncodeToBytes(bytes, 0, bytes.Length);
        }

        public static byte[] UrlEncodeToBytes(string str, System.Text.Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            byte[] bytes = e.GetBytes(str);
            return UrlEncodeBytesToBytesInternal(bytes, 0, bytes.Length, false);
        }

        public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
        {
            if ((bytes == null) && (count == 0))
            {
                return null;
            }
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            if ((offset < 0) || (offset > bytes.Length))
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if ((count < 0) || ((offset + count) > bytes.Length))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            return UrlEncodeBytesToBytesInternal(bytes, offset, count, true);
        }

        public string Boundary
        {
            get
            {
                string[] strArray = this.ContentType.Split(new char[] { ';' });
                if (strArray[0].Trim().ToLower() == "multipart/form-data")
                {
                    string[] strArray2 = strArray[1].Split(new char[] { '=' });
                    return ("--" + strArray2[1]);
                }
                return null;
            }
        }

        public string ContentType
        {
            get
            {
                return "multipart/form-data; boundary=---------------------------7d5b915500cee";
            }
        }

        public System.Text.Encoding Encoding
        {
            get
            {
                return this.encoding;
            }
            set
            {
                this.encoding = value;
            }
        }

        private class UrlDecoder
        {
            private int _bufferSize;
            private byte[] _byteBuffer;
            private char[] _charBuffer;
            private Encoding _encoding;
            private int _numBytes;
            private int _numChars;

            public UrlDecoder(int bufferSize, Encoding encoding)
            {
                this._bufferSize = bufferSize;
                this._encoding = encoding;
                this._charBuffer = new char[bufferSize];
            }

            public void AddByte(byte b)
            {
                if (this._byteBuffer == null)
                {
                    this._byteBuffer = new byte[this._bufferSize];
                }
                this._byteBuffer[this._numBytes++] = b;
            }

            public void AddChar(char ch)
            {
                if (this._numBytes > 0)
                {
                    this.FlushBytes();
                }
                this._charBuffer[this._numChars++] = ch;
            }

            private void FlushBytes()
            {
                if (this._numBytes > 0)
                {
                    this._numChars += this._encoding.GetChars(this._byteBuffer, 0, this._numBytes, this._charBuffer, this._numChars);
                    this._numBytes = 0;
                }
            }

            public string GetString()
            {
                if (this._numBytes > 0)
                {
                    this.FlushBytes();
                }
                if (this._numChars > 0)
                {
                    return new string(this._charBuffer, 0, this._numChars);
                }
                return string.Empty;
            }
        }
    }
}

