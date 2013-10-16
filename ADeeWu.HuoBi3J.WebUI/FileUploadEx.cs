using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ADeeWu.HuoBi3J.WebUI
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:FileUploadEx runat=server></{0}:FileUploadEx>")]
    public class FileUploadEx : FileUpload
    {
        public FileUploadEx()
        {
            
        }

        /// <summary>
        /// 允许的文件扩展列表,多个扩展名用 | 分隔
        /// </summary>
        public string AllowFileExt
        {
            get {
                string value =(System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.WebUI.FileUploadEx.AllowFileExt"] ?? string.Empty);
                value = ViewState["UploadFile_AllowFileExt"] == null ? value : ViewState["UploadFile_AllowFileExt"].ToString();
                return value;
            }
            set { ViewState["UploadFile_AllowFileExt"] = value; }
        }

        /// <summary>
        /// 文件上传路径根
        /// </summary>
        public string UploadRoot
        {
            get
            {
                string value = (System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.WebUI.FileUploadEx.UploadRoot"] ?? string.Empty);
                value = ViewState["UploadFile_UploadRoot"] == null ? value : ViewState["UploadFile_UploadRoot"].ToString();
                return value;
            }
            set { ViewState["UploadFile_UploadRoot"] = value; }
        }

        /// <summary>
        /// 上传文件允许大小,单位:Byte
        /// </summary>
        public int AllowFileSize
        {
            get
            {
                string s = (System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.WebUI.FileUploadEx.AllowFileSize"] ?? string.Empty);
                s = ViewState["UploadFile_AllowFileSize"] == null ? s : ViewState["UploadFile_AllowFileSize"].ToString();
                int value = 0;
                int.TryParse(s, out value);
                return value;
            }
            set { ViewState["UploadFile_AllowFileSize"] = value; }
        }

        /// <summary>
        /// 上传默认值,当用户没有选择新的文件进行上传时,调用GetUploadedFilePath方法可以获得该值
        /// </summary>
        /// <remarks>
        /// 用于存放上一次上传的图片地址,提交表单时该值不会作为上传文件
        /// </remarks>
        public string DefaultValue
        {
            get {
                string s = ViewState["UploadFile_DefaultValue"] == null ? string.Empty : ViewState["UploadFile_DefaultValue"].ToString();
                return s;
            }
            set { ViewState["UploadFile_DefaultValue"] = value; }
        }

        ///// <summary>
        ///// 拒绝的文件扩展列表,多个扩展名用 | 分隔
        ///// </summary>
        //public string DenyFileExt
        //{
        //    get { return ViewState["DenyFileExt"] ?? System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.WebUI.FileUploadEx.DenyFileExt"]; }
        //    set { ViewState["DenyFileExt"] = value; }
        //}

        /// <summary>
        /// 验证上传文件包括文件类型,文件大小
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        {
            if (!ValidFileExt()) return false;
            if (!ValidFileSize()) return false;
            return true;
        }

        /// <summary>
        /// 根据当前设定的AllowFileExt属性验证上传文件类型
        /// </summary>
        /// <returns></returns>
        public bool ValidFileExt()
        {
            return ValidFileExt(this.AllowFileExt.Split('|'));
        }

        /// <summary>
        /// 根据指定的文件类型列表进行验证上传文件类型
        /// </summary>
        /// <param name="fileExtList"></param>
        /// <returns></returns>
        public bool ValidFileExt(params string[] fileExtList)
        {
            string fileExt = GetFileExt();
            if (fileExt.Length == 0) return false;
            fileExt = fileExt.Substring(1);
            foreach (string extName in fileExtList)
            {
                if (string.Compare(extName, fileExt, true) == 0) return true;
            }

            if (this.AllowFileExt.LastIndexOf(fileExt) < 0) return false;
            return false;
        }

        /// <summary>
        /// 根据指定允许文件大小(单位:Bytes)进行验证上传文件大小
        /// </summary>
        /// <param name="allowBytes"></param>
        /// <returns></returns>
        public bool ValidFileSize(long allowBytes)
        {
            if (this.PostedFile == null) return false;
            if (this.PostedFile.ContentLength > allowBytes) return false;
            return true;
        }
        
        /// <summary>
        /// 根据指定的AllowFileSize属性进行验证上传文件大小
        /// </summary>
        /// <returns></returns>
        public bool ValidFileSize()
        {
            return ValidFileSize(this.AllowFileSize);
        }



        public string GetFileExt()
        {
            if (this.PostedFile == null) return string.Empty;
            int index = this.FileName.LastIndexOf('.');
            if (index < 0) return string.Empty;
            return this.FileName.Substring(index);
        }

        /// <summary>
        /// 根据当前上下文来保存文件,在执行保存文件前会先验证上下文配置(成功:返回文件路径,失败:返回空字符)
        /// </summary>
        /// <returns>返回文件URL</returns>
        public string Save()
        {
            if (!Valid()) return string.Empty;
            if (!this.HasFile) return string.Empty;
            string fileExt = GetFileExt();
            string path = this.UploadRoot;
            if (path.Length == 0) return string.Empty;
            if(!path.EndsWith("/") && !path.EndsWith("\\")){
                path+="/";
            }
            string savePath = path + DateTime.Now.ToString("yyyy-MM-dd") + "/";
            //自动创建日期目录

            if (!Directory.Exists(this.Page.Server.MapPath(savePath)))
            {
                Directory.CreateDirectory(this.Page.Server.MapPath(savePath));
            }
            if (this.uploadedFilePath.Length == 0)
            {
                //string saveFileName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-") + DateTime.Now.Millisecond + fileExt;
                string saveFileName = Guid.NewGuid().ToString() + fileExt;
                string fullFileName = savePath + saveFileName;
                this.uploadedFilePath = fullFileName;
            }
            this.SaveAs(this.Page.Server.MapPath(this.uploadedFilePath));
            return this.uploadedFilePath;
        }

        private string uploadedFilePath = string.Empty;

        /// <summary>
        /// 获取文件保存路径
        /// </summary>
        /// <returns></returns>
        public string GetUploadedFilePath()
        {
            if (!Valid()) return this.DefaultValue;
            string fileExt = GetFileExt();
            string path = this.UploadRoot;
            if (path.Length == 0) return this.DefaultValue;
            if (!path.EndsWith("/") && !path.EndsWith("\\"))
            {
                path += "/";
            }
            string savePath = path + DateTime.Now.ToString("yyyy-MM-dd") + "/";
            //string saveFileName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-") + DateTime.Now.Millisecond + fileExt;
            string saveFileName = Guid.NewGuid().ToString() + fileExt;
            string fullFileName = savePath + saveFileName;
            this.uploadedFilePath = fullFileName;
            return fullFileName;
        }
    }
}
