
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
    
public partial class Сеансы
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Сеансы()
    {

        this.Билеты = new HashSet<Билеты>();

        this.СтоимостьБилетов = new HashSet<СтоимостьБилетов>();

    }


    public int ID { get; set; }

    public Nullable<int> IDФильма { get; set; }

    public Nullable<int> IDЗала { get; set; }

    public string Дата { get; set; }

    public string Время { get; set; }

    public Nullable<bool> Премьера { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Билеты> Билеты { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<СтоимостьБилетов> СтоимостьБилетов { get; set; }

    public virtual Фильмы Фильмы { get; set; }

    public virtual Залы Залы { get; set; }

}

}
