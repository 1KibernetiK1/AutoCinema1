
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace AutoCinema.DataBase
{

using System;
    using System.Collections.Generic;
    
public partial class РазмерыЗалов
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public РазмерыЗалов()
    {

        this.Залы = new HashSet<Залы>();

    }


    public int ID { get; set; }

    public string Наименование { get; set; }

    public Nullable<int> КоличествоРядов { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Залы> Залы { get; set; }

}

}
