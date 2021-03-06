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
    
    public partial class Gamme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gamme()
        {
            this.Devis = new HashSet<Devis>();
            this.Caracteristique = new HashSet<Caracteristique>();
            this.Module = new HashSet<Module>();
        }
    
        public int id { get; set; }
        public string nom_gamme { get; set; }
        public string famille_couverture { get; set; }
        public string famille_isolant { get; set; }
        public string famille_finition_exterieure { get; set; }
        public string mode_conception_ossature { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public string famille_gamme { get; set; }
        public int id_unite_dusage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Devis> Devis { get; set; }
        public virtual FamilleGamme FamilleGamme { get; set; }
        public virtual UniteDusage UniteDusage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caracteristique> Caracteristique { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Module> Module { get; set; }
    }
}
