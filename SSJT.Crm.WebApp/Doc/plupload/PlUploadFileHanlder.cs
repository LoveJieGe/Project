using SSJT.Crm.Common;
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
        protected override bool OnUploadChunk(Stream chunkStream, int chunk, int chunks, string uploadedFilename)
        {
            byte[] bytes = new byte[chunkStream.Length];
            chunkStream.Read(bytes, 0, bytes.Length);
            chunkStream.Seek(0, SeekOrigin.Begin);

            bool result = false;
            try
            {
                result = FileHelper.OnUploadChunk(bytes, chunk, chunks, uploadedFilename);
            }
            catch (Exception e)
            {
                WriteErrorResponse(GetExceptMsg(e), 100, false);
            }

            return result;
        }
    }
}