
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
    
public partial class Залы
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Залы()
    {

        this.Билеты = new HashSet<Билеты>();

        this.Сеансы = new HashSet<Сеансы>();

    }


    public int ID { get; set; }

    public Nullable<int> НомерЗала { get; set; }

    public Nullable<int> IDРазмера { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Билеты> Билеты { get; set; }

    public virtual РазмерыЗалов РазмерыЗалов { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Сеансы> Сеансы { get; set; }

}

}
