using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AutoUpdate
{
    /// <summary>
    /// �汾��
    /// </summary>
    public class Version : IComparable
    {
        string _strVersion = string.Empty;
        int _valueVersion = 0;
        string _ifuse = string.Empty;
        string _entryPoint = string.Empty;
        string _serverUrl = string.Empty;
        string _updateflag = "1";
        
        public Version(string strVersion, int valueVersion, string ifuse ,  string updateflag , string entrypoint , string serverurl )
        {
            this._strVersion = strVersion;
            this._valueVersion = valueVersion;
            this._ifuse = ifuse;
            this._entryPoint = entrypoint;
            this._serverUrl = serverurl;
            this._updateflag = updateflag;
        }

        public Version() { }
        /// <summary>
        /// �汾����
        /// </summary>
        public string StrVersion
        {
            get { return _strVersion; }
            set { _strVersion = value; }
        }
        /// <summary>
        /// �汾��ʶ
        /// </summary>
        public int ValueVersion
        {
            get { return _valueVersion; }
            set { _valueVersion = value; }
        }
        /// <summary>
        /// �汾״̬
        /// </summary>
        public string Ifuse
        {
            get { return _ifuse; }
            set { _ifuse = value; }
        }
        /// <summary>
        /// �����������
        /// </summary>
        public string EntryPoint
        {
            get { return _entryPoint; }
            set { _entryPoint = value; }
        }
        /// <summary>
        /// ����˸��µ�ַ
        /// </summary>
        public string ServerUrl
        {
            get { return _serverUrl; }
            set { _serverUrl = value; }
        }
        /// <summary>
        /// �汾������ʶ��1���������� �� 0���Ƽ�������
        /// </summary>
        public string Updateflag
        {
            get { return _updateflag; }
            set { _updateflag = value; }
        }

        #region IComparable ��Ա

        public int CompareTo(object obj)
        {
            Version temp = obj as Version;
            if (temp == null) return -1;
            return this._valueVersion.CompareTo(temp._valueVersion);
        }

        #endregion
    }
    /// <summary>
    /// �ļ��б�
    /// </summary>
    public class FileModel
    {
        string _fileName = string.Empty;
        string _fileUri = string.Empty;
        string _tempPath = string.Empty;
        string _fileVersion = string.Empty;
        int _verSionValue = 0;
        /// <summary>
        /// �ļ�����
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        /// <summary>
        /// �ļ����ص�ַ
        /// </summary>
        public string FileUri
        {
            get { return _fileUri; }
            set { _fileUri = value; }
        }
        /// <summary>
        /// �ļ���ʱ·��
        /// </summary>
        public string TempPath
        {
            get { return _tempPath; }
            set { _tempPath = value; }
        }
        /// <summary>
        /// �ļ��汾��Ϣ
        /// </summary>
        public string FileVersion
        {
            get { return _fileVersion; }
            set { _fileVersion = value; }
        }
        /// <summary>
        /// �汾��ʶ
        /// </summary>
        public int VersionValue
        {
            get { return _verSionValue; }
            set { _verSionValue = value; }
        }
    }
}
