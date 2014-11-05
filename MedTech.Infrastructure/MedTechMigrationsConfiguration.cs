using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedTech.Core.Domain.Membership;
using MedTech.Core.Domain.CompanyInfo;
using MedTech.Core.Domain.TextResources;

namespace MedTech.Infrastructure
{
    public class MedTechMigrationsConfiguration : DbMigrationsConfiguration<MedTechObjectContext>
    {
        public MedTechMigrationsConfiguration()
        {
            //Gets or sets a value indicating if automatic migrations can be used when migrating the database.
            AutomaticMigrationsEnabled = true;
            //Gets or sets a value indicating if data loss is acceptable during automatic migration. 
            //If set to false an exception will be thrown if data loss may occur as part of an automatic migration.
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MedTechObjectContext context)
        {
            if (!context.Set<Role>().Any() && !context.Set<User>().Any())
            {
                context.Set<Role>().Add(new Role { Id = (long)RoleEnum.Admin, Name = Enum.GetName(typeof(RoleEnum), (long)RoleEnum.Admin) });
                context.Set<Role>().Add(new Role { Id = (long)RoleEnum.Manager, Name = Enum.GetName(typeof(RoleEnum), (long)RoleEnum.Manager) });

                context.Set<User>().Add(new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@medtech.com",
                    Password = "G1w4UiQ+TkUNrsRnx+UZ32xcdmXd/RiMmx2MAS3gn5A=",
                    Salt = "VfKmAcO3kxWWvSumYfc5lhlngBvme+oUUUtyrmm4vfM=",
                    Phone = "+37529",
                    RoleId = (long)RoleEnum.Admin

                });
            }
            if (!context.Set<CompanyInfo>().Any())
            {
                context.Set<CompanyInfo>().Add(new CompanyInfo
                {
                    Id = 1,
                    Name = "MedTech Company",
                    Description = "The best company.",
                    Address = "Minsk"
                });
            }

            if(!context.Set<TextResource>().Any())
            {
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Common.Save", Value = "Сохранить" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Common.Create", Value = "Создать" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Common.Edit", Value = "Редактировать" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Common.Delete", Value = "Удалить" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Common.Cancel", Value = "Отмена" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Common.Panel", Value = "Панель администратора" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Common.Settings", Value = "Настройки" });
                
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Common.Warning.Delete", Value = "Вы уверены, что хотите удалить?" });
                
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.TextResource.Title", Value = "Текстовые ресурсы" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.TextResource.Key", Value = "Ключ" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.TextResource.Value", Value = "Значение" });                
                
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Users.Title", Value = "Пользователи" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Users.FirstName", Value = "Имя" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Users.LastName", Value = "Фамилия" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Users.Email", Value = "Email" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Users.Phone", Value = "Телефон" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Users.LastLoginDate", Value = "Дата последнего входа" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Users.Role", Value = "Роль" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Users.Password", Value = "Пароль" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Admin.Users.Create.Title", Value = "Создание пользователя" });
                
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Common.Login", Value = "Вход" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Common.Logout", Value = "Выход" });
                context.Set<TextResource>().Add(new TextResource { Id = 1, Key = "Common.Search", Value = "Поиск" });
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
