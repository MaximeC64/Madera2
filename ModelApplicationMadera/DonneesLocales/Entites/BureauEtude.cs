//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelApplicationMadera.DonneesLocales.Entites
{
    using System;
    using System.Collections.Generic;
    
    public partial class BureauEtude
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BureauEtude()
        {
            this.Module = new HashSet<Module>();
        }
    
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string mot_de_passe { get; set; }
        public string service { get; set; }
        public string tel { get; set; }
        public string tel_portable { get; set; }
        public string poste { get; set; }
        public System.DateTime date__heure_de_connexion { get; set; }
        public string userMaderaname { get; set; }
        public string categorie { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    
        public virtual UserMadera UserMadera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Module> Module { get; set; }
    }
}