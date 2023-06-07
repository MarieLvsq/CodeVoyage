using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;

namespace CodeVoyage.Models
{
	
        public class BddContext : DbContext
        {
            public DbSet<Evenement> Evenements { get; set; }
            //public DbSet<Catalogue> Catalogues{ get; set; }
            public DbSet<Itineraire> Itineraires { get; set; }
            public DbSet<Membre> Membres { get; set; }
            public DbSet<OffreVoyage> OffreVoyages { get; set; }
            public DbSet<Partenaire> Partenaires { get; set; }
            public DbSet<Reservation> Reservations { get; set; }
            public DbSet<Service> Services { get; set; }
            public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql("server=localhost;user id=root;password=MMMMM;database=CodeVoyageBDD");

        }
        public void InitializeDb()
        {
           this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Evenements.AddRange(
                new Evenement
                {
                    Id = 1,
                    Nom = "Carnaval de Rio",
                    DateDeb = new DateTime(2024, 02, 09),
                    DateFin = new DateTime(2024, 02, 17),
                    Localisation = "Rio",
                    TypeEvenement = ((TypeEvenement)3)
                },
                new Evenement
                {
                    Id = 2,
                    Nom = "Caribana festival",
                    DateDeb = new DateTime(2023, 08, 03),
                    DateFin = new DateTime(2023, 08, 07),
                    Localisation = "Toronto",
                    TypeEvenement = ((TypeEvenement)3)

                },
                new Evenement
                {
                    Id = 3,
                    Nom = "Atlanta Arts",
                    DateDeb = new DateTime(2023, 09, 19),
                    DateFin = new DateTime(2023, 09, 20),
                    Localisation = "Piedmont Park",
                    TypeEvenement = ((TypeEvenement)1)

                },
                new Evenement
                {
                    Id = 4,
                    Nom = "San Francisco Fall Antiques Show",
                    DateDeb = new DateTime(2023, 10, 01),
                    DateFin = new DateTime(2023, 10, 31),
                    Localisation = "San Francisco",
                    TypeEvenement = ((TypeEvenement)1)

                },
                 new Evenement
                 {
                     Id = 5,
                     Nom = "Carnaval de Venise",
                     DateDeb = new DateTime(2023, 02, 03),
                     DateFin = new DateTime(2023, 02, 13),
                     Localisation = "Venise",
                     TypeEvenement = ((TypeEvenement)3)

                 },
                  new Evenement
                  {
                      Id = 6,
                      Nom = "Coupe d'Afrique des nations (CAN)",
                      DateDeb = new DateTime(2023, 01, 13),
                      DateFin = new DateTime(2023, 02, 11),
                      Localisation = "Abidjan",
                      TypeEvenement = ((TypeEvenement)2)

                  },

                  new Evenement
                  {
                      Id = 7,
                      Nom = "Rock in Rio ",
                      DateDeb = new DateTime(2023, 09, 01),
                      DateFin = new DateTime(2023, 09, 30),
                      Localisation = "Rio de Janeiro",
                      TypeEvenement = ((TypeEvenement)1)

                  },
                   new Evenement
                   {
                       Id = 8,
                       Nom = "Oktoberfest ",
                       DateDeb = new DateTime(2023, 09, 16),
                       DateFin = new DateTime(2023, 10, 03),
                       Localisation = "Munich",
                       TypeEvenement = ((TypeEvenement)0)

                   },
                    new Evenement
                    {
                        Id = 9,
                        Nom = "Qatar Grand Prix (Formule 1)",
                        DateDeb = new DateTime(2023, 10, 06),
                        DateFin = new DateTime(2023, 10, 08),
                        Localisation = "Doha",
                        TypeEvenement = ((TypeEvenement)2)

                    },
                    new Evenement
                    {
                        Id = 10,
                        Nom = "Dubaï Shopping Festival",
                        DateDeb = new DateTime(2024, 12, 01),
                        DateFin = new DateTime(2024, 12, 31),
                        Localisation = "Doha",
                        TypeEvenement = ((TypeEvenement)1)

                    },
                     new Evenement
                     {
                         Id = 11,
                         Nom = "Euro 2024, Paris",
                         DateDeb = new DateTime(2024, 06, 14),
                         DateFin = new DateTime(2024, 07, 14),
                         Localisation = "Paris",
                         TypeEvenement = ((TypeEvenement)2)

                     },
                      new Evenement
                      {
                          Id = 12,
                          Nom = "Coupe du Monde Rugby",
                          DateDeb = new DateTime(2023, 09, 08),
                          DateFin = new DateTime(2023, 10, 28),
                          Localisation = "Paris",
                          TypeEvenement = ((TypeEvenement)2)

                      }


                );
            this.Itineraires.AddRange(
            new Itineraire
            {
                Id = 1,
                DateDepart = new DateTime(2024, 02, 07),
                DateArrivee = new DateTime(2024, 02, 21),
                LieuDepart = "Paris",
                Destination = "Rio De Janeiro",
                NombreVoyageur = 40,
                Transport = ((MoyenDeTransport)0),
                Prix = 560
            },
            new Itineraire
            {
                Id = 2,
                DateDepart = new DateTime(2023, 06, 30),
                DateArrivee = new DateTime(2023, 07, 14),
                LieuDepart = "Paris",
                Destination = "Toronto",
                NombreVoyageur = 50,
                Transport = ((MoyenDeTransport)0),
                Prix = 575
            },
            new Itineraire
            {
                Id = 3,
                DateDepart = new DateTime(2023, 10, 15),
                DateArrivee = new DateTime(2023, 11, 01),
                LieuDepart = "Paris",
                Destination = "San Francisco",
                NombreVoyageur = 30,
                Transport = ((MoyenDeTransport)0),
                Prix = 560

            },

            new Itineraire
            {
                Id = 4,
                DateDepart = new DateTime(2023, 08, 02),
                DateArrivee = new DateTime(2023, 08, 08),
                LieuDepart = "Paris",
                Destination = "Toronto",
                NombreVoyageur = 50,
                Transport = ((MoyenDeTransport)0),
                Prix = 575


            },
            new Itineraire
            {
                Id = 5,
                DateDepart = new DateTime(2023, 10, 01),
                DateArrivee = new DateTime(2023, 10, 15),
                LieuDepart = "Paris",
                Destination = "Venise",
                NombreVoyageur = 20,
                Transport = ((MoyenDeTransport)2),
                Prix = 80

            },
            new Itineraire
            {
                Id = 6,
                DateDepart = new DateTime(2023, 10, 02),
                DateArrivee = new DateTime(2023, 10, 14),
                LieuDepart = "Paris",
                Destination = "Venise",
                NombreVoyageur = 20,
                Transport = ((MoyenDeTransport)0),
                Prix = 160

            },
            new Itineraire

            {
                Id = 7,
                DateDepart = new DateTime(2023, 01, 11),
                DateArrivee = new DateTime(2023, 01, 25),
                LieuDepart = "Paris",
                Destination = "Abidjan",
                NombreVoyageur = 20,
                Transport = ((MoyenDeTransport)0),
                Prix = 403

            },
            new Itineraire

            {
                Id = 8,
                DateDepart = new DateTime(2023, 02, 01),
                DateArrivee = new DateTime(2023, 02, 13),
                LieuDepart = "Paris",
                Destination = "Abidjan",
                NombreVoyageur = 20,
                Transport = ((MoyenDeTransport)0),
                Prix = 403

            },
            new Itineraire

            {
                Id = 9,
                DateDepart = new DateTime(2023, 02, 06),
                DateArrivee = new DateTime(2023, 02, 10),
                LieuDepart = "Paris",
                Destination = "Doha",
                NombreVoyageur = 20,
                Transport = ((MoyenDeTransport)0),
                Prix = 359

            },
            new Itineraire
            {
                Id = 10,
                DateDepart = new DateTime(2023, 09, 15),
                DateArrivee = new DateTime(2023, 10, 04),
                LieuDepart = "Paris",
                Destination = "Munich",
                NombreVoyageur = 20,
                Transport = ((MoyenDeTransport)0),
                Prix = 232

            },
             new Itineraire
             {
                 Id = 11,
                 DateDepart = new DateTime(2023, 09, 15),
                 DateArrivee = new DateTime(2023, 10, 04),
                 LieuDepart = "Paris",
                 Destination = "Munich",
                 NombreVoyageur = 20,
                 Transport = ((MoyenDeTransport)2),
                 Prix = 196

             },
              new Itineraire
              {
                  Id = 13,
                  DateDepart = new DateTime(2024, 07, 25),
                  DateArrivee = new DateTime(2024, 08, 11),
                  LieuDepart = "Lyon",
                  Destination = "Paris",
                  NombreVoyageur = 15,
                  Transport = ((MoyenDeTransport)2),
                  Prix = 150

              },
              new Itineraire
              {
                  Id = 14,
                  DateDepart = new DateTime(2023, 07, 25),
                  DateArrivee = new DateTime(2023, 08, 11),
                  LieuDepart = "Toulouse",
                  Destination = "Paris",
                  NombreVoyageur = 15,
                  Transport = ((MoyenDeTransport)2),
                  Prix = 180

              },
               new Itineraire
               {
                   Id = 15,
                   DateDepart = new DateTime(2023, 07, 25),
                   DateArrivee = new DateTime(2023, 08, 11),
                   LieuDepart = "Toulouse",
                   Destination = "Paris",
                   NombreVoyageur = 15,
                   Transport = ((MoyenDeTransport)0),
                   Prix = 250

               },
               new Itineraire
               {
                   Id = 16,
                   DateDepart = new DateTime(2023, 06, 13),
                   DateArrivee = new DateTime(2023, 07, 15),
                   LieuDepart = "Toulouse",
                   Destination = "Paris",
                   NombreVoyageur = 15,
                   Transport = ((MoyenDeTransport)2),
                   Prix = 180

               },
                new Itineraire
                {
                    Id = 17,
                    DateDepart = new DateTime(2023, 06, 13),
                    DateArrivee = new DateTime(2023, 07, 15),
                    LieuDepart = "Toulouse",
                    Destination = "Paris",
                    NombreVoyageur = 08,
                    Transport = ((MoyenDeTransport)0),
                    Prix = 300

                },
                 new Itineraire
                 {
                     Id = 18,
                     DateDepart = new DateTime(2023, 08, 18),
                     DateArrivee = new DateTime(2023, 08, 21),
                     LieuDepart = "Paris",
                     Destination = "Atlanta",
                     NombreVoyageur = 08,
                     Transport = ((MoyenDeTransport)0),
                     Prix = 315

                 },
                  new Itineraire
                  {
                      Id = 19,
                      DateDepart = new DateTime(2023, 10, 06),
                      DateArrivee = new DateTime(2023, 10, 10),
                      LieuDepart = "Paris",
                      Destination = "Doha",
                      NombreVoyageur = 08,
                      Transport = ((MoyenDeTransport)0),
                      Prix = 470

                  }

             );
         
             this.Services.AddRange(
            new Service
                 {
                     Id = 1,
                     nomService = "Pas de service",
                     Capacite = 0,
                     DateDeb = new DateTime(2023, 07, 01),
                     DateFin = new DateTime(2023, 09, 03),
                     TypeService = ((TypeService)0),
                     Prix = 0
                },
                new Service
                {
                    Id = 2,
                    nomService = "Visite du Corcovado",
                    Capacite = 20,
                    DateDeb = new DateTime(2023, 10, 21),
                    DateFin = new DateTime(2024, 12, 20),
                    TypeService = ((TypeService)4),
                    Prix = 10
                },
                new Service
                {
                    Id = 3,
                    nomService = "Mini golf",
                    Capacite = 9,
                    DateDeb = new DateTime(2023, 07, 01),
                    DateFin = new DateTime(2023, 09, 03),
                    TypeService = ((TypeService)2),
                    Prix = 12
                },
                new Service
                {
                    Id = 4,
                    nomService = "Location de limousine à l'heure",
                    Capacite = 2,
                    DateDeb = new DateTime(2023, 06, 01),
                    DateFin = new DateTime(2024, 06, 01),
                    TypeService = ((TypeService)3),
                    Prix = 200
                },
                new Service
                {
                    Id = 5,
                    nomService = "Safari dans le désert de Doha",
                    Capacite = 6,
                    DateDeb = new DateTime(2023, 02, 07),
                    DateFin = new DateTime(2024, 02, 07),
                    TypeService = ((TypeService)2),
                    Prix = 90
                },
                 new Service
                 {
                     Id = 6,
                     nomService = " Restauration locale Abidjan",
                     Capacite = 10,
                     DateDeb = new DateTime(2023, 01, 15),
                     DateFin = new DateTime(2024, 01, 15),
                     TypeService = ((TypeService)0),
                     Prix = 15
                 },

                  new Service
                  {
                      Id = 7,
                      nomService = " Restauration locale Rio",
                      Capacite = 10,
                      DateDeb = new DateTime(2023, 02, 12),
                      DateFin = new DateTime(2024, 02, 12),
                      TypeService = ((TypeService)0),
                      Prix = 10
                  },
                   new Service
                   {
                       Id = 8,
                       nomService = " Balade privée en gondole Venise",
                       Capacite = 5,
                       DateDeb = new DateTime(2023, 02, 07),
                       DateFin = new DateTime(2024, 02, 07),
                       TypeService = ((TypeService)2),
                       Prix = 50
                   },
                    new Service
                    {
                        Id = 9,
                        nomService = " location voiture Sixt: Venise",
                        Capacite = 5,
                        DateDeb = new DateTime(2023, 02, 03),
                        DateFin = new DateTime(2024, 02, 13),
                        TypeService = ((TypeService)3),
                        Prix = 300
                    },
                     new Service
                     {
                         Id = 10,
                         nomService = " location voiture Sixt: Abidjan",
                         Capacite = 5,
                         DateDeb = new DateTime(2023, 01, 11),
                         DateFin = new DateTime(2024, 01, 25),
                         TypeService = ((TypeService)3),
                         Prix = 300
                     },
                      new Service
                      {
                          Id = 11,
                          nomService = " location voiture Sixt: Abidjan",
                          Capacite = 5,
                          DateDeb = new DateTime(2023, 02, 01),
                          DateFin = new DateTime(2024, 02, 13),
                          TypeService = ((TypeService)3),
                          Prix = 300
                      },
                      new Service
                      {
                          Id = 12,
                          nomService = " Holiday Inn: Rio",
                          Capacite = 40,
                          DateDeb = new DateTime(2024, 02, 01),
                          DateFin = new DateTime(2025, 02, 28),
                          TypeService = ((TypeService)1),
                          Prix = 400

                      },
                      new Service
                      {
                          Id = 13,
                          nomService = " Billet Tour Eiffel, Visite Musée du Louvre ",
                          Capacite = 40,
                          DateDeb = new DateTime(2024, 06, 20),
                          DateFin = new DateTime(2025,06, 24),
                          TypeService = ((TypeService)2),
                          Prix = 97
                      },
                       new Service
                       {
                           Id = 14,
                           nomService = " Holiday Inn: Toronto",
                           Capacite = 40,
                           DateDeb = new DateTime(2023, 08, 03),
                           DateFin = new DateTime(2025, 08, 07),
                           TypeService = ((TypeService)1),
                           Prix = 500

                       },
                        new Service
                        {
                            Id = 15,
                            nomService = " Holiday Inn: Atlanta",
                            Capacite = 40,
                            DateDeb = new DateTime(2023, 09, 19),
                            DateFin = new DateTime(2025, 09, 20),
                            TypeService = ((TypeService)1),
                            Prix = 145

                        },
                          
                        new Service
                        {
                            Id = 16,
                            nomService = " Holiday Inn: Paris",
                            Capacite = 100,
                            DateDeb = new DateTime(2024, 01, 01),
                            DateFin = new DateTime(2025, 01, 31),
                            TypeService = ((TypeService)1),
                            Prix = 150

                        }

                      );


            this.Partenaires.AddRange(
            new Partenaire
            {
                Id = 1,
                Nom = "Holiday Inn",
                Localisation = "Paris",
                email = "service-reservation@holidayinn.com",
                NumSiret = "10120125630",
                TypeService = ((TypeService)2),
                Role = Role.Entreprise
            },
            new Partenaire
            {
                Id = 2,
                Nom = "Air France",
                Localisation = "Paris",
                email = "flights-booking@air-france.fr",
                NumSiret = "87895000000000",
                TypeService = TypeService.Transport,
                Role = Role.Entreprise
            },
            new Partenaire
            {
                Id = 3,
                Nom = "Cozinha Tradicional",
                Localisation = "Rio de Janeiro",
                email = "cozinha@gmail.com",
                NumSiret = "1882378500",
                TypeService = TypeService.Restauration,
                Role = Role.Entreprise
            },
             new Partenaire
             {
                 Id = 4,
                 Nom = "Le Débarcadère",
                 Localisation = "Abidjan",
                 email = "ledebarcadere@gmail.com",
                 NumSiret = "1882378507",
                 TypeService = TypeService.Restauration,
                 Role = Role.Entreprise
             },
                new Partenaire
                {
                    Id = 5,
                    Nom = "Sixt",
                    Localisation = "Abidjan",
                    email = "sixt@gmail.com",
                    NumSiret = "1882378509",
                    TypeService = TypeService.Transport,
                    Role = Role.Entreprise
                }
            );

             this.Membres.AddRange(
             new Membre
            {
                Id = 1,
                Nom = "Garou",
                Prenom = "Vincent",
                Email="V.garou@gmail.com",
                MotDePasse=Dal.EncodeMD5 ("AAAAA"),
                
                Localisation = "Torento",
                Age = 43,
                User = Role.Association
            },
              new Membre
              {
                  Id = 2,
                  Nom = "DION",
                  Prenom = "Jean",
                  Email = "jean.dion@gmail.com",
                  MotDePasse = Dal.EncodeMD5("DADA"),
                  
                  Localisation = "Paris",
                  Age = 32,
                  User =Role.Particulier
              },

                new Membre
                {
                    Id = 3,
                    Nom = "DILAN",
                    Prenom = "Robert",
                    Email = "robertDilan@gmail.com",
                    MotDePasse = "AAAAA",
                   
                    Localisation = "Bruxelles",
                    Age = 23,
                    User = Role.Entreprise

                },
                 new Membre
                  {
                      Id = 4,
                      Nom = "GASPARD",
                      Prenom = "Lea",
                      Email = "l.gaspard@gmail.com",
                     MotDePasse = "AAAAA",
                     
                      Localisation= "Orléans",
                      Age = 25,
                      User = Role.Entreprise
                  },

                 new Membre
                 {
                     Id = 5,
                     Nom = "Mirales",
                     Prenom = "Octave",
                     Email = "omirales@gmail.com",
                     MotDePasse = "AAAAA",
                    
                     Localisation = "Geneve",
                     Age = 71,
                     User = Role.Particulier
                 });
            this.OffreVoyages.AddRange(
           new OffreVoyage
           {
               Id = 1,
               ItineraireId = 1,
               EventId = 1,
               ServiceId = 4,
               ServiceExId = 1,
               Remise = 0,
             
               prixTotal =760,

           },
           new OffreVoyage 
           {
               Id = 2,
               ItineraireId = 2,
               EventId = 2,
               ServiceId = 1,
               ServiceExId = 3,
               Remise = 0,

               prixTotal = 587,

           },
            new OffreVoyage
            {
                Id = 3,
                ItineraireId = 2,
                EventId = 2,
                ServiceId = 14,
                ServiceExId = 1,
                Remise = 0,

                prixTotal = 1075,

            },
            new OffreVoyage
            {
                Id = 4,
                ItineraireId = 14,
                EventId = 11,
                ServiceId = 1,
                ServiceExId = 13,
                Remise = 0,

                prixTotal = 277,

            },
              new OffreVoyage
              {
                  Id = 5,
                  ItineraireId = 3,
                  EventId = 4,
                  ServiceId = 1,
                  ServiceExId = 3,
                  Remise = 0,

                  prixTotal = 572,

              },
               new OffreVoyage
               {
                   Id = 6,
                   ItineraireId = 18,
                   EventId = 3,
                   ServiceId = 15,
                   ServiceExId = 1,
                   Remise = 0,

                   prixTotal = 460,

               },
               new OffreVoyage
               {
                   Id = 7,
                   ItineraireId = 9,
                   EventId = 9,
                   ServiceId = 1,
                   ServiceExId = 5,
                   Remise = 0,

                   prixTotal = 449,

               },
                new OffreVoyage
                {
                    Id = 8,
                    ItineraireId = 13,
                    EventId = 11,
                    ServiceId = 1,
                    ServiceExId = 13,
                    Remise = 0,

                    prixTotal = 247,

                }








           );
            this.Admins.AddRange(
           new Admin
           {
               Id = 1,
               Nom = "David",
               Prenom = "AITCHEOU",
               Email = "Dav@gmail.com",
               MotDePasse = Dal.EncodeMD5("OnePiece")

           });

           ;

            this.SaveChanges();
        }

    }
    
}

