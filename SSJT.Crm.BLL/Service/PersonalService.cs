using SSJT.Crm.Core;
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
        public PersonalNote InsertData(PersonalNote model)
        {
            IPersonalNoteService service = new PersonalNoteService();
            model.NoteID = SqlHelper.GenerateTableID();
            service.Add(model);
            return model;
        }
    }
}
