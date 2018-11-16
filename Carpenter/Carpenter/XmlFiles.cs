using System;
using System.IO;
using System.Xml;

namespace AutoUpdate
{
	/// <summary>
	/// XmlFiles  �ļ�������
	/// </summary>
	public class XmlFiles : XmlDocument
	{
		#region �ֶ�������
		private string _xmlFilePath;
		public string XmlFilePath
		{
            set { _xmlFilePath = value; }
            get { return _xmlFilePath; }
		}
		#endregion

		public XmlFiles(string xmlFile)
		{
            XmlFilePath = xmlFile;			
			this.Load(xmlFile);
		}
		/// <summary>
		/// ����һ���ڵ��xPath���ʽ������һ���ڵ�
		/// </summary>
		public XmlNode FindNode(string xPath)
		{
			XmlNode xmlNode = this.SelectSingleNode(xPath);
			return xmlNode;           
		}
		/// <summary>
		/// ����һ���ڵ��xPath���ʽ������ֵ
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public string GetNodeValue(string xPath)
		{
			XmlNode xmlNode = this.SelectSingleNode(xPath);
            if (xmlNode == null) return string.Empty;
			return xmlNode.InnerText;
		}
		/// <summary>
		/// ����һ���ڵ�ı��ʽ���ش˽ڵ��µĺ��ӽڵ��б�
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public XmlNodeList GetChildNodeList(string xPath)
		{
            XmlNode curNode = this.SelectSingleNode(xPath);
            if (curNode == null) return null;
			XmlNodeList nodeList = curNode.ChildNodes;
			return nodeList;
		}
        public XmlNodeList GetNodeList(string xPath)
        {
            XmlNodeList nodeList = this.SelectNodes(xPath);
            return nodeList;
        }
	}
}
