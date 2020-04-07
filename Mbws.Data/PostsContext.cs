using Mbws.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbws.Data
{
    /// <summary>
    /// Performs CreateReadUpdateDelete operations on the associated DataBase
    /// </summary>
    public class PostsContext : DbContext
    {
        DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MbwsAppData");
        }

        /// <summary>
        /// Create & Save Changes
        /// </summary>
        /// <param name="newPost"></param>
        public void Create(Post newPost)
        {
            Posts.Add(newPost);
            SaveChanges();
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<Post> Read(Guid ID)
        {
            var arr = await Posts.ToArrayAsync();
            return arr.Where(p => p.Id.Equals(ID)).FirstOrDefault();
        }

        /// <summary>
        /// Read all posts.
        /// </summary>
        /// <returns></returns>
        public async Task<Post[]> Read()
        {
            return await Posts.ToArrayAsync();
        }

        /// <summary>
        /// Update & Save Changes
        /// </summary>
        /// <param name="newPost"></param>
        public void Update(Post newPost)
        {
            Posts.Update(newPost);
            SaveChanges();
        }

        /// <summary>
        /// Delete & Save Changes
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task Delete(Guid ID)
        {
            var arr = await Posts.ToArrayAsync();
            Posts.Remove(arr
                .Where(p => p.Id.Equals(ID))
                .FirstOrDefault());
            SaveChanges();
        }
    }
}