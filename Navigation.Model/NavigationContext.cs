﻿

// ------------------------------------------------------------------------------------------------
// This code was generated by EntityFramework Reverse POCO Generator (http://www.reversepoco.com/).
// Created by Simon Hughes (https://about.me/simon.hughes).
//
// Do not make changes directly to this file - edit the template instead.
//
// The following connection settings were used to generate this file:
//     Configuration file:     "Navigation.Model\App.config"
//     Connection String Name: "NavigationContext"
//     Connection String:      "Data Source=.\sqlexpress;Initial Catalog=Navigation;Persist Security Info=True;User ID=Navigation;password=**zapped**;;MultipleActiveResultSets=True"
// ------------------------------------------------------------------------------------------------
// Database Edition       : Express Edition (64-bit)
// Database Engine Edition: Express

// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Navigation.Model
{
    using System.Linq;

    #region Unit of work

    public interface IMyDbContext : System.IDisposable
    {
        System.Data.Entity.DbSet<Category> Categories { get; set; } // Category
        System.Data.Entity.DbSet<Navigate> Navigates { get; set; } // Navigate
        System.Data.Entity.DbSet<UserInfo> UserInfoes { get; set; } // UserInfo

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

    #endregion

    #region Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class MyDbContext : System.Data.Entity.DbContext, IMyDbContext
    {
        public System.Data.Entity.DbSet<Category> Categories { get; set; } // Category
        public System.Data.Entity.DbSet<Navigate> Navigates { get; set; } // Navigate
        public System.Data.Entity.DbSet<UserInfo> UserInfoes { get; set; } // UserInfo

        static MyDbContext()
        {
            System.Data.Entity.Database.SetInitializer<MyDbContext>(null);
        }

        public MyDbContext()
            : base("Name=NavigationContext")
        {
        }

        public MyDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public MyDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public MyDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public MyDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new NavigateConfiguration());
            modelBuilder.Configurations.Add(new UserInfoConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new NavigateConfiguration(schema));
            modelBuilder.Configurations.Add(new UserInfoConfiguration(schema));
            return modelBuilder;
        }
    }
    #endregion

    #region Fake Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class FakeMyDbContext : IMyDbContext
    {
        public System.Data.Entity.DbSet<Category> Categories { get; set; }
        public System.Data.Entity.DbSet<Navigate> Navigates { get; set; }
        public System.Data.Entity.DbSet<UserInfo> UserInfoes { get; set; }

        public FakeMyDbContext()
        {
            Categories = new FakeDbSet<Category>("CategoryId");
            Navigates = new FakeDbSet<Navigate>("NavId");
            UserInfoes = new FakeDbSet<UserInfo>("UserId");
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1);
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public System.Data.Entity.Infrastructure.DbChangeTracker _changeTracker;
        public System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get { return _changeTracker; } }
        public System.Data.Entity.Infrastructure.DbContextConfiguration _configuration;
        public System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get { return _configuration; } }
        public System.Data.Entity.Database _database;
        public System.Data.Entity.Database Database { get { return _database; } }
        public System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity)
        {
            throw new System.NotImplementedException();
        }
        public System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors()
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet Set(System.Type entityType)
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

    }

    // ************************************************************************
    // Fake DbSet
    // Implementing Find:
    //      The Find method is difficult to implement in a generic fashion. If
    //      you need to test code that makes use of the Find method it is
    //      easiest to create a test DbSet for each of the entity types that
    //      need to support find. You can then write logic to find that
    //      particular type of entity, as shown below:
    //      public class FakeBlogDbSet : FakeDbSet<Blog>
    //      {
    //          public override Blog Find(params object[] keyValues)
    //          {
    //              var id = (int) keyValues.Single();
    //              return this.SingleOrDefault(b => b.BlogId == id);
    //          }
    //      }
    //      Read more about it here: https://msdn.microsoft.com/en-us/data/dn314431.aspx
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class FakeDbSet<TEntity> : System.Data.Entity.DbSet<TEntity>, IQueryable, System.Collections.Generic.IEnumerable<TEntity>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity> where TEntity : class
    {
        private readonly System.Reflection.PropertyInfo[] _primaryKeys;
        private readonly System.Collections.ObjectModel.ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public FakeDbSet(params string[] primaryKeys)
        {
            _primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (_primaryKeys == null)
                throw new System.ArgumentException("No primary keys defined");
            if (keyValues.Length != _primaryKeys.Length)
                throw new System.ArgumentException("Incorrect number of keys passed to Find method");

            var keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => _primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(System.Threading.CancellationToken cancellationToken, params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken);
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues));
        }

        public override System.Collections.Generic.IEnumerable<TEntity> AddRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new System.ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Add(entity);
            }
            return items;
        }

        public override TEntity Add(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override System.Collections.Generic.IEnumerable<TEntity> RemoveRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new System.ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Remove(entity);
            }
            return items;
        }

        public override TEntity Remove(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Remove(item);
            return item;
        }

        public override TEntity Attach(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return System.Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return System.Activator.CreateInstance<TDerivedEntity>();
        }

        public override System.Collections.ObjectModel.ObservableCollection<TEntity> Local
        {
            get { return _data; }
        }

        System.Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Collections.Generic.IEnumerator<TEntity> System.Collections.Generic.IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator<TEntity> System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class FakeDbAsyncQueryProvider<TEntity> : System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public FakeDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            return new FakeDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            return new FakeDbAsyncEnumerable<TElement>(expression);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public System.Threading.Tasks.Task<object> ExecuteAsync(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute(expression));
        }

        public System.Threading.Tasks.Task<TResult> ExecuteAsync<TResult>(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute<TResult>(expression));
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeDbAsyncEnumerable(System.Collections.Generic.IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public FakeDbAsyncEnumerable(System.Linq.Expressions.Expression expression)
            : base(expression)
        { }

        public System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator System.Data.Entity.Infrastructure.IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<T>(this); }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class FakeDbAsyncEnumerator<T> : System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T>
    {
        private readonly System.Collections.Generic.IEnumerator<T> _inner;

        public FakeDbAsyncEnumerator(System.Collections.Generic.IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public System.Threading.Tasks.Task<bool> MoveNextAsync(System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object System.Data.Entity.Infrastructure.IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }

    #endregion

    #region POCO classes

    // Category
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class Category
    {
        public int CategoryId { get; set; } // CategoryId (Primary key)
        public int FatherCategoryId { get; set; } // FatherCategoryId
        public string CategoryName { get; set; } // CategoryName (length: 20)
        public bool HaveSub { get; set; } // HaveSub
        public int Sort { get; set; } // Sort
        public string Ico { get; set; } // Ico (length: 20)
        public int UserId { get; set; } // UserId
        public System.DateTime ModifiedOn { get; set; } // ModifiedOn

        public Category()
        {
            HaveSub = false;
        }
    }

    // Navigate
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class Navigate
    {
        public int NavId { get; set; } // NavId (Primary key)
        public int CategoryId { get; set; } // CategoryId
        public int UserId { get; set; } // UserId
        public string Title { get; set; } // Title (length: 50)
        public int Sort { get; set; } // Sort
        public string Pic { get; set; } // Pic (length: 128)
        public string ReMark { get; set; } // ReMark
        public int ClickTime { get; set; } // ClickTime
        public System.DateTime ModifyTime { get; set; } // ModifyTime

        public Navigate()
        {
            ClickTime = 0;
        }
    }

    // UserInfo
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class UserInfo
    {
        public int UserId { get; set; } // UserId (Primary key)
        public string UserName { get; set; } // UserName (length: 20)
        public string Pwd { get; set; } // Pwd (length: 64)
        public string Email { get; set; } // Email (length: 64)
        public string Phone { get; set; } // Phone (length: 11)
        public System.DateTime ModifiedOn { get; set; } // ModifiedOn

        public UserInfo()
        {
            ModifiedOn = System.DateTime.Now;
        }
    }

    #endregion

    #region POCO Configuration

    // Category
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class CategoryConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
            : this("dbo")
        {
        }

        public CategoryConfiguration(string schema)
        {
            ToTable("Category", schema);
            HasKey(x => x.CategoryId);

            Property(x => x.CategoryId).HasColumnName(@"CategoryId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FatherCategoryId).HasColumnName(@"FatherCategoryId").HasColumnType("int").IsRequired();
            Property(x => x.CategoryName).HasColumnName(@"CategoryName").HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(x => x.HaveSub).HasColumnName(@"HaveSub").HasColumnType("bit").IsRequired();
            Property(x => x.Sort).HasColumnName(@"Sort").HasColumnType("int").IsRequired();
            Property(x => x.Ico).HasColumnName(@"Ico").HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("int").IsRequired();
            Property(x => x.ModifiedOn).HasColumnName(@"ModifiedOn").HasColumnType("datetime").IsRequired();
        }
    }

    // Navigate
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class NavigateConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Navigate>
    {
        public NavigateConfiguration()
            : this("dbo")
        {
        }

        public NavigateConfiguration(string schema)
        {
            ToTable("Navigate", schema);
            HasKey(x => x.NavId);

            Property(x => x.NavId).HasColumnName(@"NavId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CategoryId).HasColumnName(@"CategoryId").HasColumnType("int").IsRequired();
            Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("int").IsRequired();
            Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.Sort).HasColumnName(@"Sort").HasColumnType("int").IsRequired();
            Property(x => x.Pic).HasColumnName(@"Pic").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.ReMark).HasColumnName(@"ReMark").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.ClickTime).HasColumnName(@"ClickTime").HasColumnType("int").IsRequired();
            Property(x => x.ModifyTime).HasColumnName(@"ModifyTime").HasColumnType("datetime").IsRequired();
        }
    }

    // UserInfo
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public class UserInfoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
            : this("dbo")
        {
        }

        public UserInfoConfiguration(string schema)
        {
            ToTable("UserInfo", schema);
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).HasColumnName(@"UserName").HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(x => x.Pwd).HasColumnName(@"Pwd").HasColumnType("nvarchar").IsRequired().HasMaxLength(64);
            Property(x => x.Email).HasColumnName(@"Email").HasColumnType("nvarchar").IsRequired().HasMaxLength(64);
            Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(11);
            Property(x => x.ModifiedOn).HasColumnName(@"ModifiedOn").HasColumnType("datetime").IsRequired();
        }
    }

    #endregion

}
// </auto-generated>

