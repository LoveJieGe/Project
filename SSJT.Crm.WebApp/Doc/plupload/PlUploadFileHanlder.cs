using SSJT.Crm.Common;
using SSJT.Crm.WebApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp.Doc
{
    public class PlUploadFileHandler:PlUploadBaseHandler
    {
        /// <summary>
        /// Stream each chunk to a file and effectively append it. 
        /// </summary>
        /// <param name="chunkStream"></param>
        /// <param name="chunk"></param>
        /// <param name="chunks"></param>
        /// <param name="uploadedFilename"></param>
        /// <returns></returns>
        protected override bool OnUploadChunk(PluploadFile pfile)
        {

            bool result = false;
            try
            {
                result = PluploadHelper.OnUploadChunk(pfile);
            }
            catch (Exception e)
            {
                WriteErrorResponse(GetExceptMsg(e), 100, false);
            }

            return result;
        }
    }
}