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
    
    public partial class Devis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Devis()
        {
            this.CommandeClient = new HashSet<CommandeClient>();
            this.LigneDevis = new HashSet<LigneDevis>();
        }
    
        public int id { get; set; }
        public string nom { get; set; }
        public System.DateTime date { get; set; }
        public decimal dossier_devis { get; set; }
        public decimal dossier_technique { get; set; }
        public int pourcentage_tva { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public int id_projet { get; set; }
        public string nom_statut_devis { get; set; }
        public int id_gamme { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommandeClient> CommandeClient { get; set; }
        public virtual Gamme Gamme { get; set; }
        public virtual Projet Projet { get; set; }
        public virtual StatutDevis StatutDevis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneDevis> LigneDevis { get; set; }
    }
}
