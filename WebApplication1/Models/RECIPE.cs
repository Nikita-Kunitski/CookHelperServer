//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RECIPE
    {
        public int C_id { get; set; }
        public int C_id_ingred { get; set; }
        public int C_id_dish { get; set; }
        public int kol { get; set; }
    
        public virtual BOOK_DISH BOOK_DISH { get; set; }
        public virtual INGREDIENT INGREDIENT { get; set; }
    }
}
