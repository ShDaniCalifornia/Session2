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
    
    public partial class BookTransfers
    {
        public int IDTransfer { get; set; }
        public int IDBook { get; set; }
        public string OldCipher { get; set; }
        public string NewCipher { get; set; }
        public System.DateTime TransferDate { get; set; }
    
        public virtual Books Books { get; set; }
    }
}
