//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GibddApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Взыскания
    {
        public int КодНарушения { get; set; }
        public Nullable<System.DateTime> ДатаВремяНарушения { get; set; }
        public string НомерВУ { get; set; }
        public string РайонНарушения { get; set; }
        public string РазмерШтрафа { get; set; }
        public Nullable<bool> ОплаченШтраф { get; set; }
        public Nullable<int> СрокЛишенияПрав { get; set; }
        public Nullable<int> БазоваяВеличина { get; set; }
        public Nullable<int> ЛичныйНомерИнспектора { get; set; }
    
        public virtual НарушенияПДД НарушенияПДД { get; set; }
        public virtual Инспектора Инспектора { get; set; }
        public virtual Водители Водители { get; set; }
    }
}
