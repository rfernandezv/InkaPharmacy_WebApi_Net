using EnterprisePatterns.Api.Movies.Domain.Enum;
using System;

namespace EnterprisePatterns.Api.Movies.Domain.Entity
{
    public class Movie
    {
        public virtual long Id { get; protected set; }
        public virtual string Name { get; }
        public virtual DateTime ReleaseDate { get; }
        public virtual MpaaRating MpaaRating { get; }
        public virtual string Genre { get; }
        public virtual double Rating { get; }
        public virtual Director Director { get; }

        protected Movie()
        {
        }
    }
}
