//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterPol__TestDemo_
{
    using System;
    using System.Collections.Generic;
    
    public partial class PartnerType
    {
        public PartnerType()
        {
            this.Partner = new HashSet<Partner>();
        }
    
        public int partner_type_id { get; set; }
        public string partner_type_name { get; set; }
    
        public virtual ICollection<Partner> Partner { get; set; }
    }
}
