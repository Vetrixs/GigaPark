﻿using GigaPark.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace GigaPark.Database.Helpers
{
    /// <summary>
    ///     Stellt den Kontext zur Datenbank bereit. <br></br> Diese Klasse erbt von der <see cref="DbContext" />-Klasse, die
    ///     eine aktive Instanz einer Datenbankverbindung repräsentiert.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        ///     <para>
        ///         Override this method to configure the database (and other options) to be used for this context.
        ///         This method is called for each instance of the context that is created.
        ///         The base implementation does nothing.
        ///     </para>
        ///     <para>
        ///         In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may
        ///         not have been passed
        ///         to the constructor, you can use
        ///         <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        ///         the options have already been set, and skip some or all of the logic in
        ///         <see
        ///             cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />
        ///         .
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        ///     for more information.
        /// </remarks>
        /// <param name="optionsBuilder">
        ///     A builder used to create or modify options for this context. Databases (and other extensions)
        ///     typically define extension methods on this object that allow you to configure the context.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
             * SQLite Datenbank verwenden.
             * Die Datenbankdatei wird im Ordner der Executable erstellt und ist demnach lokal.
             */
            optionsBuilder.UseSqlite("Data Source=parkhouse.db");
        }

#pragma warning disable CS8618
        /// <summary>
        ///     Gibt den Datenbanksatz für die Parkplätze an oder legt diesen fest.
        /// </summary>
        public DbSet<ParkingSpot> Spots { get; set; }

        /// <summary>
        ///     Gibt den Datenbanksatz für die Parkscheine an oder legt diesen fest.
        /// </summary>
        public DbSet<ParkingTicket> Tickets { get; set; }
#pragma warning restore CS8618
    }
}