using System.Linq;
using BusinessLogic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class PostService_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_writes_to_database()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new DataContext(options))
                {
                    EnsureCreated(context);
                }

                using (var context = new DataContext(options))
                {
                    var service = new PostService(context);
                    service.Add("cat", "https://cat.com");
                    context.SaveChanges();
                }

                using (var context = new DataContext(options))
                {
                    //check if post was added
                    Assert.AreEqual(1, context.Posts.Count());
                    //check title of post added
                    Assert.AreEqual("cat", context.Posts.Single().Title);
                    //check if blog was added with post
                    Assert.IsNotNull(context.Posts.Include(p => p.Blog));
                    //check url of blog
                    Assert.AreEqual("https://cat.com", context.Blogs.SingleOrDefault().Url);
                }
            }
            finally
            {
                connection.Close();
            }
        }
        [Test]
        public void Find_searches_title()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new DataContext(options))
                {
                    EnsureCreated(context);
                }

                using (var context = new DataContext(options))
                {
                    context.Posts.Add(new Post { Title = "cats", Blog = new Blog { Url = "cat.com" } });
                    context.Posts.Add(new Post { Title = "catfish", Blog = new Blog { Url = "fish.com" } });
                    context.Posts.Add(new Post { Title = "dogs", Blog = new Blog { Url = "dog.com" } });
                    context.SaveChanges();
                }

                using (var context = new DataContext(options))
                {
                    var service = new PostService(context);
                    var result = service.Find("cat");
                    Assert.AreEqual(2, result.Count());
                }
            }
            finally
            {
                connection.Close();
            }
        }
        [Test]
        public void Update_edits_database()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new DataContext(options))
                {
                    EnsureCreated(context);
                }

                using (var context = new DataContext(options))
                {
                    context.Posts.Add(new Post { Title = "cats", Blog = new Blog { Url = "cat.com" } });
                    context.Posts.Add(new Post { Title = "fishes is fresh", Blog = new Blog { Url = "fish.com" } });
                    context.Posts.Add(new Post { Title = "dogs is delicious", Blog = new Blog { Url = "dog.com" } });
                    context.SaveChanges();
                }

                using (var context = new DataContext(options))
                {
                    var service = new PostService(context);
                    service.Update(1, "cats is cute");
                    context.SaveChanges();

                }
                using (var context = new DataContext(options))
                {
                    //check the number of post to ensure no change in number
                    Assert.AreEqual(3, context.Posts.Count());
                    //check the data inserted
                    Assert.AreEqual("cats is cute", context.Posts.SingleOrDefault(x => x.PostId == 1).Title);
                }
            }
            finally
            {
                connection.Close();
            }
        }
        [Test]
        public void Delete_deletes_from_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new DataContext(options))
                {
                    EnsureCreated(context);
                }

                using (var context = new DataContext(options))
                {
                    context.Posts.Add(new Post { Title = "cats", Blog = new Blog { Url = "cat.com" } });
                    context.Posts.Add(new Post { Title = "fishes is fresh", Blog = new Blog { Url = "fish.com" } });
                    context.Posts.Add(new Post { Title = "dogs is delicious", Blog = new Blog { Url = "dog.com" } });
                    context.SaveChanges();
                }

                using (var context = new DataContext(options))
                {
                    var service = new PostService(context);
                    service.Delete(1);
                    context.SaveChanges();

                }
                using (var context = new DataContext(options))
                {
                    //check id of the post deleted if still exists or not
                    Assert.IsNull(context.Posts.Where(p => p.PostId == 1).FirstOrDefault());
                    //check the number of post to ensure
                    Assert.AreEqual(2, context.Posts.Count());
                }
            }
            finally
            {
                connection.Close();
            }
        }
        private static void EnsureCreated(DataContext context)
        {
            if (context.Database.EnsureCreated())
            {
                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                viewCommand.CommandText = @"CREATE VIEW AllPosts AS SELECT Title FROM Posts;";
                viewCommand.ExecuteNonQuery();
            }
        }
    }
}