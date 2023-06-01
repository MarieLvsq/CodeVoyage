using System;
using System.Collections.Generic;
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
                    DateDeb = new DateTime(2023, 07, 01),
                    DateFin = new DateTime(2023, 08, 30),
                    Localisation = "Toronto",
                    TypeEvenement = ((TypeEvenement)3)

                },
                new Evenement
                {
                    Id = 3,
                    Nom = "Atlanta Arts",
                    DateDeb = new DateTime(2023, 09, 01),
                    DateFin = new DateTime(2023, 09, 30),
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
                DateDepart = new DateTime(2023, 09, 15),
                DateArrivee = new DateTime(2023, 11, 25),
                LieuDepart = "Test",
                Destination = "Toronto",
                NombreVoyageur = 50,
                Transport = ((MoyenDeTransport)0),
                Prix = 575

            });

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
                    nomService= "Visite du Corcovado",
                    Capacite= 20,
                    DateDeb= new DateTime(2023, 10, 21),
                    DateFin= new DateTime(2024, 12, 20),
                    TypeService=((TypeService)4),
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
                    TypeService = ((TypeService)1),
                    Prix = 200
                });
            this.Partenaires.AddRange(
            new Partenaire
            {
                Id = 1,
                Nom = "Holiday Inn",
                Localisation = "Paris",
                email = "service-reservation@holidayinn.com",
                NumSiret = "10120125630",
                TypeService = ((TypeService)2),
                Role = Role.Entreprise,
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
            });

             this.Membres.AddRange(
             new Membre
            {
                Id = 1,
                Nom = "Garou",
                Prenom = "Vincent",
                Email="V.garou@gmail.com",
                Statut = Statut.Bronze,
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
                  Statut = Statut.Argent,
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
                    Statut = Statut.Diamant,
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
                      Statut = Statut.Platine,
                      Localisation = "Orléans",
                      Age = 25,
                      User = Role.Entreprise
                  },

                 new Membre
                 {
                     Id = 5,
                     Nom = "Mirales",
                     Prenom = "Octave",
                     Email = "omirales@gmail.com",
                     Statut = Statut.Or,
                     Localisation = "Geneve",
                     Age = 71,
                     User = Role.Admin
                 }); ;

            this.SaveChanges();
        }

    }
    
}

