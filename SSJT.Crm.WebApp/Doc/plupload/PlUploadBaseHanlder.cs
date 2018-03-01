using SSJT.Crm.Common;
using SSJT.Crm.WebApp.AjaxHandler;
using SSJT.Crm.WebApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace SSJT.Crm.WebApp.Doc
{
    public class PlUploadBaseHandler:BaseRequest
    {
        // Don't use HttpContext.Current - Async handlers don't see it
        protected HttpContext Context;
        protected HttpResponse Response;
        protected HttpRequest Request;
        /// <summary>
        /// Maximum upload size in bytes
        /// default: 0 = unlimited
        /// </summary>
        protected int MaxUploadSize = 0;

        /// <summary>
        /// Comma delimited list of extensions allowed,
        /// extension preceded by a dot.
        /// Example: .jpg,.png
        /// </summary>
        protected string AllowedExtensions = ".jpg,.jpeg,.png,.gif,.bmp";

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            Context = context;
            Request = context.Request;
            Response = context.Response;

            // Check to see whether there are uploaded files to process them
            if (Request.Files.Count > 0)
            {
                PluploadFile pfile = new PluploadFile(context);
                
                if (!("," + AllowedExtensions.ToLower() + ",").Contains("," + pfile.FileExtension.ToLower() + ","))
                {
                    WriteErrorResponse("文件类型不允许", 100, true);
                    return;
                }
                
                // If there are no chunks sent the file is sent as one 
                // this likely a plain HTML 4 upload (ie. 1 single file)
                if (pfile.Chunks == -1)
                {
                    if (MaxUploadSize == 0 || Request.ContentLength <= MaxUploadSize)
                    {
                        if (!OnUploadChunk(pfile))
                            return;
                    }
                    else
                    {
                        WriteErrorResponse("文件太大", 413, true);
                        return;
                    }
                    OnUploadCompleted(pfile);
                    return;
                }
                else
                {
                    // this isn't exact! We can't see the full size of the upload
                    // and don't know the size of the last chunk
                    if (pfile.Chunk == 0 && MaxUploadSize > 0 && Request.ContentLength * (pfile.Chunks - 1) > MaxUploadSize)
                    {
                        WriteErrorResponse("文件太大", 413, true);
                        return;
                    }
                }
                if (!OnUploadChunkStarted(pfile))
                    return;
                // chunk 0 is the first one
                if (pfile.Chunk == 0)
                {
                    if (!OnUploadStarted(pfile))
                        return;
                }
                if (!OnUploadChunk(pfile))
                    return;
                // last chunk
                if (pfile.Chunk >= pfile.Chunks - 1)
                {
                    // final response should just return
                    // the output you generate
                    OnUploadCompleted(pfile);
                    return;
                }
                // if no response has been written yet write a success response
                WriteSucessResponse(null);
            }
        }


        /// <summary>
        /// Writes out an error response
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="endResponse"></param>
        protected void WriteErrorResponse(string message, int statusCode, bool endResponse)
        {
            Response.ContentType = "application/json";
            Response.StatusCode = 500;

            // Write out raw JSON string to avoid JSON requirement
            Response.Write("{\"success\": false, \"code\": " + statusCode.ToString() + ", \"message\": " + JsonEncode(message) + "}");
            if (endResponse)
                Response.End();
        }

        /// <summary>
        /// Sends a message to the client for each chunk
        /// </summary>
        /// <param name="message"></param>
        protected void WriteSucessResponse(string message)
        {
            Response.ContentType = "application/json";
            string json = null;
            if (!string.IsNullOrEmpty(message))
                json = JsonEncode(message);
            else
                json = "null";

            Response.Write("{\"success\": true, \"result\" : " + json + "}");
            Response.End();
        }

        /// <summary>
        /// Use this method to write the final output in the OnUploadCompleted method
        /// to pass back a result string to the client when a file has completed
        /// uploading
        /// </summary>
        /// <param name="data"></param>
        protected void WriteUploadCompletedMessage(string data)
        {
            Response.Write(data);
        }

        /// <summary>
        /// Completion handler called when the download completes
        /// </summary>
        /// <param name="fileName"></param>
        protected virtual void OnUploadCompleted(PluploadFile pfile)
        {

        }

        /// <summary>
        /// Fired on every chunk that is sent
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="chunks"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual bool OnUploadChunkStarted(PluploadFile pfile)
        {
            return true;
        }

        /// <summary>
        /// Fired on the first chunk sent to the server - allows checking for authentication
        /// file size limits etc.
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="chunks"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual bool OnUploadStarted(PluploadFile pfile)
        {
            return true;
        }

        /// <summary>
        /// Fired as the upload happens
        /// </summary>
        /// <param name="chunkStream"></param>
        /// <param name="chunk"></param>
        /// <param name="chunks"></param>
        /// <param name="name"></param>
        /// <returns>return true on success false on failure</returns>
        protected virtual bool OnUploadChunk(PluploadFile pfile)
        {
            return true;
        }

        /// <summary>
        /// Encode JavaScript
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string JsonEncode(object value)
        {
            var ser = new JavaScriptSerializer();
            return ser.Serialize(value);
        }



        protected static string GetExceptMsg(Exception ex)
        {
            var sb = new StringBuilder();
            var exception = ex;
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

#if DEBUG
            sb.Append(exception.GetType().FullName + ": ");
#endif
            sb.Append(exception.Message);
#if DEBUG
            sb.Append("\r\n" + exception.StackTrace);
#endif
            return sb.ToString();
        }
    }
}