using SSJT.Crm.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp.Common
{
    public class PluploadFile
    {
        public PluploadFile(HttpContext context)
        {
            this.Context = context;
            this.Init();
        }
        public HttpContext Context
        {
            get;
            private set;
        }
        public string SourceFileName
        {
            get;
            private set;
        }
        public string ScreenFileName
        {
            get;private set;
        }
        public string FileExtension
        {
            get;private set;
        }
        public bool IsScreenFile
        {
            get;private set;
        }
        
        public int Chunk
        {
            get;
            private set;
        }
        public int Chunks
        {
            get;
            private set;
        }
        public HttpPostedFile FileUpload
        {
            get;
            private set;
        }
        private void Init()
        {
            HttpRequest request = this.Context.Request;
            if (request.Files.Count > 0)
            {
                string userID = request["UserID"];
                IsScreenFile = false;
                this.FileUpload = request.Files[0];
                SourceFileName = this.FileUpload.FileName;
                if (string.IsNullOrEmpty(SourceFileName) || string.Equals(SourceFileName, "blob"))
                    SourceFileName = request["name"] ?? string.Empty;
                // normalize file name to avoid directory traversal attacks            
                SourceFileName = Path.GetFileName(SourceFileName);
                FileExtension = Path.GetExtension(SourceFileName);

                if (!string.IsNullOrEmpty(userID))
                {

                    if (SourceFileName.Contains(userID))
                    {
                        ScreenFileName = Helper.FromHex(userID) + "_screen" + FileExtension;
                        IsScreenFile = true;
                    }
                    else
                    {
                        ScreenFileName = Helper.FromHex(userID) + "_source" + FileExtension;
                    }
                }
                string tstr = request["chunks"] ?? string.Empty;
                int chunks = -1;
                if (!int.TryParse(tstr, out chunks))
                    chunks = -1;
                Chunks = chunks;
                tstr = request["chunk"] ?? string.Empty;
                int chunk = -1;
                if (!int.TryParse(tstr, out chunk))
                    chunk = -1;
                Chunk = chunk;
            }
        }
    }
}