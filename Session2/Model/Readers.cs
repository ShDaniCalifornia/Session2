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
    
    public partial class Readers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Readers()
        {
            this.BookLoans = new HashSet<BookLoans>();
            this.ReaderRegistrations = new HashSet<ReaderRegistrations>();
        }
    
        public int IDReader { get; set; }
        public string TicketNumber { get; set; }
        public string Surname { get; set; }
        public string PassportNumber { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EducationLevel { get; set; }
        public Nullable<bool> AcademicDegree { get; set; }
        public Nullable<int> IDReadingRoom { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public Nullable<System.DateTime> LastRegistrationUpdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookLoans> BookLoans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReaderRegistrations> ReaderRegistrations { get; set; }
        public virtual ReadingRooms ReadingRooms { get; set; }
    }
}
