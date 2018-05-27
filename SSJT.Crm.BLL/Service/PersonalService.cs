using SSJT.Crm.Core;
using SSJT.Crm.Core.Exceptions;
using SSJT.Crm.IBLL;
using SSJT.Crm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.BLL
{
    public class PersonalService: IPersonalService
    {
        private IPersonalNoteService _noteService = null;
        internal IPersonalNoteService NoteService
        {
            get
            {
                if (this._noteService == null)
                {
                    _noteService = new PersonalNoteService();
                }
                return this._noteService;
            }
        }
        private INewsService _newsService = null;
        internal INewsService NewsService
        {
            get
            {
                if (this._newsService == null)
                {
                    _newsService = new NewsService();
                }
                return this._newsService;
            }
        }
        #region 便签
        public PersonalNote InsertData(PersonalNote model)
        {
            model.NoteID = SqlHelper.GenerateTableID();
            NoteService.Add(model);
            return model;
        }
        public PersonalNote UpdateData(PersonalNote model)
        {
            PersonalNote info = NoteService.LoadEntity(p => p.NoteID == model.NoteID);
            if (info == null)
                throw AjaxException.ToException(ErrorCode.DataLostCode, "数据已丢失或已删除");
            info.CopyFrom(model);
            NoteService.Update(info);
            return info;
        }
        public void DeleteNote(string noteId)
        {
            PersonalNote info = NoteService.LoadEntity(p => p.NoteID == noteId);
            if (info == null)
                throw AjaxException.ToException(ErrorCode.DataLostCode,"数据已丢失或已删除");
            NoteService.Delete(info);
        }

        public PersonalNote FinishNote(string noteId)
        {
            PersonalNote info = NoteService.LoadEntity(p => p.NoteID == noteId);
            if (info == null)
                throw AjaxException.ToException(ErrorCode.DataLostCode, "数据已丢失或已删除");
            info.IsFinish = "Y";
            info.FinishDate = DateTime.Now;
            NoteService.Update(info);
            return info;
        }
        #endregion
        #region 新闻
        public int InsertNews(News news)
        {
            int newsId = 10000;
            News maxNews = NewsService.GetMaxModel();
            if (maxNews != null)
            {
                newsId = maxNews.NewsId + 1;
            }
            news.NewsId = newsId;
            NewsService.Add(news);
            return newsId;
        }
        #endregion
    }
}
