//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReaderRegistrations
    {
        public int IDRegistration { get; set; }
        public int IDReader { get; set; }
        public string OldTicketNumber { get; set; }
        public string NewTicketNumber { get; set; }
        public System.DateTime RegistrationDate { get; set; }
    
        public virtual Readers Readers { get; set; }
    }
}