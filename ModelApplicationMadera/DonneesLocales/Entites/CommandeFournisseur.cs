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
    
    public partial class CommandeFournisseur
    {
        public int id { get; set; }
        public System.DateTime date_creation { get; set; }
        public System.DateTime date_relance { get; set; }
        public System.DateTime date_livraison { get; set; }
        public int nombre_relances { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public int id_fournisseur { get; set; }
        public Nullable<int> id_commande_client { get; set; }
    
        public virtual CommandeClient CommandeClient { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
    }
}
