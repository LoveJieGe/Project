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
        private IPersonalNoteService _noteService = new PersonalNoteService();
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
        public PersonalNote InsertData(PersonalNote model)
        {
            model.NoteID = SqlHelper.GenerateTableID();
            NoteService.Add(model);
            return model;
        }
        public void DeleteNote(string noteId)
        {
            PersonalNote info = NoteService.LoadEntity(p => p.NoteID == noteId);
            if (info == null)
                throw AjaxException.ToException(ErrorCode.DataLostCode,"数据已丢失或已删除");
            NoteService.Delete(info);
        }
    }
}
