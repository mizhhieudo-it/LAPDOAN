using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class DATNwebtintucContext :DbContext
    {
        public DATNwebtintucContext() : base("name=DBDATNwebtintuc") { }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Series> Seriess { get; set; }
        public virtual DbSet<Tags> Tagss { get; set; }
        public virtual DbSet<StickyPosts> StickyPostss { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}