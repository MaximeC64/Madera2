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
    
    public partial class Paiement
    {
        public int id { get; set; }
        public System.DateTime date_paiement { get; set; }
        public double montant { get; set; }
        public string monnaie { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public string mode { get; set; }
        public int id_echeance_de_paiement { get; set; }
    
        public virtual EcheanceDePaiement EcheanceDePaiement { get; set; }
        public virtual ModePaiement ModePaiement { get; set; }
    }
}
